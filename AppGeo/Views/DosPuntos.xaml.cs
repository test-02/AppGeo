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
    public partial class DosPuntos : ContentPage
    {
        public DosPuntos()
        {
            InitializeComponent();

            DosUbicaciones();
        }

        private async void DosUbicaciones()
        {
            Title = "Varias chinchetas";

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

                var midLat = (position.Latitude + (position2.Latitude)) / 2;
                var midLng = (position.Longitude + (position2.Longitude)) / 2;

                var midPoint = new MapSpan(new Xamarin.Forms.Maps.Position(midLat, midLng), 2, 2);

                map.MoveToRegion(midPoint);
            }
        }
    }
}