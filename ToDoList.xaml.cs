using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace GorsellProgramlamaOdev1
{
    public partial class ToDoList : ContentPage
    {
        private readonly string JsonFilePath;

        public ObservableCollection<string> Tasks { get; set; }

        public ToDoList()
        {
            InitializeComponent();
            BindingContext = this;

           
            JsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.json");

            Tasks = LoadTasks();
            taskListView.ItemsSource = Tasks;
        }

        private ObservableCollection<string> LoadTasks()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string json = File.ReadAllText(JsonFilePath);
                    return JsonSerializer.Deserialize<ObservableCollection<string>>(json);
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }

            return new ObservableCollection<string>();
        }

        private void SaveTasks()
        {
            try
            {
                string json = JsonSerializer.Serialize(Tasks);
                File.WriteAllText(JsonFilePath, json);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            string task = taskEntry.Text;
            if (!string.IsNullOrEmpty(task))
            {
                Tasks.Add(task);
                taskEntry.Text = string.Empty;
                SaveTasks(); 
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string task)
            {
                string newTask = await DisplayPromptAsync("Edit Task", "Enter the new task", initialValue: task);

                if (!string.IsNullOrEmpty(newTask))
                {
                    int index = Tasks.IndexOf(task);
                    Tasks[index] = newTask;
                    SaveTasks(); 
                }
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is string task)
            {
                Tasks.Remove(task);
                SaveTasks(); 
            }
        }
    }
}
