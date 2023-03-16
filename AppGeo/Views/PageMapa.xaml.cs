using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace AppGeo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapa : ContentPage
    {
        public PageMapa()
        {
            InitializeComponent();
            Ubicacion();
        }

        private async void Ubicacion()
        {
            Title = "Region del mapa con chincheta";

            var conecetividad = Connectivity.NetworkAccess;

            if (conecetividad == NetworkAccess.Internet)
            {

                var location = await Geolocation.GetLocationAsync();

                Position position = new Position(location.Latitude, location.Longitude);

                Pin pin = new Pin
                {
                    Label = "Mi Ubicacion",
                    Address = "",
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);

                map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
            }
            else 
            {
                await DisplayAlert("Alerta", "Debe conectarse al internet", "Aceptar");
            }
        }

    }
}
