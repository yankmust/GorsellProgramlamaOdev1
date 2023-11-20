﻿namespace GorsellProgramlamaOdev1
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();

            // Metin etiketlerine içerik eklemek
            Label label1 = new Label
            {
                Text = "Yankı Muştu",
                FontSize = 50,
                HorizontalOptions = LayoutOptions.CenterAndExpand, 
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            BoxView spaceBetweenLabels = new BoxView
            {
                HeightRequest = 100 // Boşluğun yüksekliği (isteğe bağlı)
            };

            Label label2 = new Label
            {
                Text = "Bartın Üniversitesi Bilgisayar Mühendisliği",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand, 
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label label3 = new Label
            {
                Text = "ÖDEV-1",
                FontSize =40,
                HorizontalOptions = LayoutOptions.CenterAndExpand, 
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // StackLayout'a eklemek
            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(label1);
            stackLayout.Children.Add(label2);
            stackLayout.Children.Add(label3);

            // Sayfa içine StackLayout ve Image eklemek
            Content = new StackLayout
            {
                Children = {
                    new Image
                    {
                        Source = "pp.png",
                        Aspect = Aspect.AspectFit,
                        WidthRequest = 200,
                        HeightRequest = 200
                    },
                    stackLayout
                }
            };
        }
    }

}