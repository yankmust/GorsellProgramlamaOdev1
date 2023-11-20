using Microsoft.Maui.Controls;

namespace GorsellProgramlamaOdev1
{
    public partial class BodyMassIndex : ContentPage
    {
        private BodyMassIndexViewModel viewModel;

        public BodyMassIndex()
        {
            InitializeComponent();
            viewModel = new BodyMassIndexViewModel();
            BindingContext = viewModel;

            // Slider'larýn deðer deðiþikliklerini dinleme
            sliderWeight.ValueChanged += OnWeightValueChanged;
            sliderHeight.ValueChanged += OnHeightValueChanged;
        }

        private void CalculateBMI()
        {
            double weight = viewModel.Weight;
            double height = viewModel.Height;

            // BMI hesaplama formülü: BMI = kilo / (boy^2)
            double bmi = weight / Math.Pow(height / 100, 2);

            // BMI sonuçlarýný deðerlendirme
            viewModel.Result = $"BMI: {bmi:F2}\n{GetBMIResult(bmi)}";
        }

        private void OnWeightValueChanged(object sender, ValueChangedEventArgs e)
        {
            viewModel.Weight = e.NewValue;
            CalculateBMI();
        }

        private void OnHeightValueChanged(object sender, ValueChangedEventArgs e)
        {
            viewModel.Height = e.NewValue;
            CalculateBMI();
        }


        private string GetBMIResult(double bmi)
        {
            if (bmi < 16)
                return "Severely Underweight";
            else if (bmi >= 16 && bmi < 17)
                return "Moderately Underweightf";
            else if (bmi >= 17 && bmi < 18.5)
                return "Mildly Underweight";
            else if (bmi >= 18.5 && bmi <= 24.9)
                return "Normal Weight";
            else if (bmi >= 25 && bmi <= 29.99)
                return "Overweight (not obese)";
            else if (bmi >= 30 && bmi <= 34.99)
                return "Class 1 (low-risk) obesity";
            else if (bmi >= 35 && bmi <= 39.99)
                return "Class 2 (moderate-risk) obesity";
            else
                return "Class 3 (high-risk) obesity";
        }
    }

    public class BodyMassIndexViewModel : BindableObject
    {
        private double _weight = 70; // Varsayýlan kilo deðeri
        private double _height = 170; // Varsayýlan boy deðeri
        private string _result;

        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
    }
}
