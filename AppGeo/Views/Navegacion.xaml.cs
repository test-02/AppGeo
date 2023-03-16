using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppGeo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navegacion : ContentPage
    {
        public Navegacion()
        {
            InitializeComponent();

            DosNavegacion();
        }

        private async void DosNavegacion()
        {
            Title = "Navegacion";

            var conecetividad = Connectivity.NetworkAccess;

            if (conecetividad == NetworkAccess.Internet)
            {

                var location = new Location(15.77, -86.76);
                var options = new MapLaunchOptions
                {
                    Name = "Casa de Joel",
                    NavigationMode = NavigationMode.Driving
                };


                await Xamarin.Essentials.Map.OpenAsync(location, options);
            }
        }

        /*private void DosNavegacion()
        {
            // Proba aqui
        }*/
    }
}