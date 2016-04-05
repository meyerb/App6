using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App6
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private DateTimeOffset _date;

        public DateTimeOffset Date
        {
            get { return _date; }
            set
            {
                _date = value;
                SetSaison(Date);
            }
        }
        public MainPage()
        {
            InitializeComponent();
            Date = DateTimeOffset.Now;
        }

        private void DatePicker_OnDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            var pick = sender as DatePicker;
            if (pick != null) Date = pick.Date;
        }

        private void SetSaison(DateTimeOffset date)
        {
            if ((date.Month == 12 && date.Day >= 22) || (date.Month <= 3 && date.Day < 20))
            {
                SetHiver();
            }
            else if (date.Month >= 3 && date.Month <= 6)
            {
                if (date.Month == 3 && date.Day < 20)
                {
                    SetHiver();
                }
                else if (date.Month == 6 && date.Day > 20)
                {
                    SetEte();
                }
                else
                {
                    SetPrintemps();
                }
            }
            else if (date.Month >= 6 && date.Month <= 9)
            {
                if (date.Month == 6 && date.Day < 21)
                {
                    SetPrintemps();
                }
                else if (date.Month == 9 && date.Day > 21)
                {
                    SetAutomne();
                }
                else
                {
                    SetEte();
                }
            }
            else
            {
                SetAutomne();
            }
        }

        private void SetHiver()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/flocon.jpg", UriKind.RelativeOrAbsolute));
            Saison.Source = bm;
            SaisonText.Text = "HIVER";
        }
        private void SetPrintemps()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/fleur.png", UriKind.RelativeOrAbsolute));
            Saison.Source = bm;
            SaisonText.Text = "PRINTEMPS";
        }
        private void SetEte()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/soleil.jpg", UriKind.RelativeOrAbsolute));
            Saison.Source = bm;
            SaisonText.Text = "ETE";
        }

        private void SetAutomne()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/feuille.jpg", UriKind.RelativeOrAbsolute));
            Saison.Source = bm;
            SaisonText.Text = "AUTOMNE";
        }
    }
}
