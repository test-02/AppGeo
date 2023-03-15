using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGeo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MiUbicacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMapa());
        }

        private async void DosUbicaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.DosPuntos());
        }

        private async void Navegacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Navegacion());
        }
    }
}
