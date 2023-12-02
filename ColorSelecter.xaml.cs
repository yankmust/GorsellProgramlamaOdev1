using System;
using Microsoft.Maui.Controls;


namespace GorsellProgramlamaOdev1
{
    public partial class Color_Selecter : ContentPage
    {
        BoxView colorBox;
        Slider redSlider, greenSlider, blueSlider;
        Label colorCodeLabel;

        public Color_Selecter()
        {
            InitializeComponent();
            

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                BackgroundColor = Color.FromRgb(255, 0, 0),
                ThumbColor = Color.FromRgb(255, 0, 0)
            };

            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                BackgroundColor = Color.FromRgb(0, 255, 0),
                ThumbColor = Color.FromRgb(0, 255, 0)
            };

            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                BackgroundColor = Color.FromRgb(0, 0, 255),
                ThumbColor = Color.FromRgb(0, 0, 255)
            };

            colorBox = new BoxView
            {
                Margin = new Thickness(5),
                WidthRequest = 700,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
                
            };

            colorCodeLabel = new Label
            {
                Text = "",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromRgb(255,255,255) 
            };

            redSlider.ValueChanged += OnSliderValueChanged;
            greenSlider.ValueChanged += OnSliderValueChanged;
            blueSlider.ValueChanged += OnSliderValueChanged;

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label { Text = "Red" },
                    redSlider,
                    new Label { Text = "Green" },
                    greenSlider,
                    new Label { Text = "Blue" },
                    blueSlider,
                    colorBox,
                    new Button { Text = "Randomize Color",Margin = new Thickness(25,0), Command = new Command(RandomizeColor), BackgroundColor=Color.FromRgb(38,38,38), TextColor=Color.FromRgb(255,255,255) },
                    new Button { Text = $"Copy Color Code {colorCodeLabel.Text}" , Margin = new Thickness(25,5), Command = new Command(CopyColorCode),BackgroundColor=Color.FromRgb(38,38,38), TextColor=Color.FromRgb(255,255,255) }
                }
            };
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            var red = (int)redSlider.Value;
            var green = (int)greenSlider.Value;
            var blue = (int)blueSlider.Value;

            colorBox.Color = Color.FromRgb(red, green, blue);
            colorCodeLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
        }

        private void RandomizeColor()
        {
            Random random = new Random();
            redSlider.Value = random.Next(256);
            greenSlider.Value = random.Next(256);
            blueSlider.Value = random.Next(256);

            UpdateColor();
        }

        private void CopyColorCode()
        {
            var colorCode = colorCodeLabel.Text;

            
            Clipboard.SetTextAsync(colorCode);
            DisplayAlert("Color Code Copied", $"Color code {colorCode} copied to clipboard.", "OK");
        }
    }
}
