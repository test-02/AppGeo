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
            // Ubicacion();

            DosPuntos();
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
        }

            private async void DosPuntos()
        {
            Title = "Region del mapa con chincheta";

            var conecetividad = Connectivity.NetworkAccess;

            if (conecetividad == NetworkAccess.Internet)
            {

                var location = await Geolocation.GetLocationAsync();

                Position position = new Position(location.Latitude, location.Longitude);

                Position position2 = new Position(15.77, -86.76);

                Pin pin = new Pin
                {
                    Label = "Mi Ubicacion",
                    Address = "",
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);

                Pin pin2 = new Pin
                {
                    Label = "Otra Ubicacion",
                    Address = "",
                    Type = PinType.Place,
                    Position = position2
                };
                map.Pins.Add(pin2);

                // map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));

                var midLat = (position.Latitude + (position2.Latitude)) / 2;
                var midLng = (position.Longitude + (position2.Longitude)) / 2;

                //Creamos un MapSpan con la posición media
                var midPoint = new MapSpan(new Xamarin.Forms.Maps.Position(midLat, midLng), 2, 2);

                //Mueve la ubicación al punto medio
                map.MoveToRegion(midPoint);

            }
        }
    }
}
