using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App6
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            set_saison(this.DateP);
        }

        private void DatePicker_OnDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            var pick = sender as DatePicker;
            set_saison(pick);
        }

        private void set_saison(DatePicker pick)
        {
            if (pick != null)
            {
                DateTimeOffset date = pick.Date;
                if ((date.Month == 12 && date.Day >= 22) || (date.Month <= 3 && date.Day < 20))
                {
                    set_hiver();
                }
                else if (date.Month >= 3 && date.Month <= 6)
                {
                    if (date.Month == 3 && date.Day < 20)
                    {
                        set_hiver();
                    }
                    else if (date.Month == 6 && date.Day > 20)
                    {
                        set_ete();
                    }
                    else
                    {
                        set_printemps();
                    }
                }
                else if (date.Month >= 6 && date.Month <= 9)
                {
                    if (date.Month == 6 && date.Day < 21)
                    {
                        set_printemps();
                    }
                    else if (date.Month == 9 && date.Day > 21)
                    {
                        set_automne();
                    }
                    else
                    {
                        set_ete();
                    }
                }
                else
                {
                    set_automne();
                }
            }
        }

        private void set_hiver()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/flocon.jpg", UriKind.RelativeOrAbsolute));
            this.Saison.Source = (ImageSource)bm;
            this.SaisonText.Text = "HIVER";
        }
        private void set_printemps()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/fleur.png", UriKind.RelativeOrAbsolute));
            this.Saison.Source = (ImageSource)bm;
            this.SaisonText.Text = "PRINTEMPS";
        }
        private void set_ete()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/soleil.jpg", UriKind.RelativeOrAbsolute));
            this.Saison.Source = (ImageSource)bm;
            this.SaisonText.Text = "ETE";
        }

        private void set_automne()
        {
            BitmapImage bm = new BitmapImage(new Uri("ms-appx:///Assets/feuille.jpg", UriKind.RelativeOrAbsolute));
            this.Saison.Source = (ImageSource)bm;
            this.SaisonText.Text = "AUTOMNE";
        }
    }
}
