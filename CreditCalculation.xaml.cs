
using System.Globalization;

namespace GorsellProgramlamaOdev1
{
    public partial class CreditCalculation : ContentPage
    {
        public CreditCalculation()
        {
            InitializeComponent();
            
            int defaultSelectedIndex = 0;

            krediTuruPicker.SelectedIndex = defaultSelectedIndex;

        }

        private void Hesapla()
        {
            double kkdf = 0;
            double bsmv = 0;

            switch (krediTuruPicker.SelectedItem.ToString())
            {
                case "Personal Loan":
                    kkdf = 15.0 / 100.0;
                    bsmv = 10.0 / 100.0;
                    break;
                case "Mortgage Loan":
                    kkdf = 0;
                    bsmv = 0;
                    break;
                case "Vehicle Loan":
                    kkdf = 15.0 / 100.0;
                    bsmv = 5.0 / 100.0;
                    break;
                case "Business Loan":
                    kkdf = 0;
                    bsmv = 5.0 / 100.0;
                    break;
            }

            double tutar = Convert.ToDouble(tutarEntry.Text);
            double oran = double.Parse(oranEntry.Text, new CultureInfo("tr-TR"));
            int tamSayiVade = (int)Math.Round(vadeSlider.Value); 

        
            double brutFaiz = ((oran + (oran * bsmv) + (oran * kkdf)) / 100);
            double taksit = ((Math.Pow(1 + brutFaiz, tamSayiVade) * brutFaiz) / (Math.Pow(1 + brutFaiz, tamSayiVade) - 1)) * tutar;
            double toplam = taksit * tamSayiVade;

            aylikTaksitLabel.Text = $"{taksit:C2}";
            toplamOdemeLabel.Text = $"{toplam:C2}";
            toplamFaizLabel.Text = $"{(toplam - tutar):C2}";

            vadeLabel.Text = tamSayiVade.ToString();
        }

        private void Hesapla_Clicked(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void VadeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Hesapla();
        }
    }
}
