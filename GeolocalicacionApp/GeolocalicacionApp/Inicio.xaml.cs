using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace GeolocalicacionApp
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var loc = CrossGeolocator.Current;
            var pos = await loc.GetPositionAsync(10000);

            if (pos == null)
            {
                await DisplayAlert("Error", "No recibo la posicion", "Ok");
            }

            txtLati.Text = pos.Latitude.ToString();
            txtLong.Text = pos.Longitude.ToString();
        }

        private void Button_Delete(object sender, EventArgs e)
        {
            txtLati.Text = "";
            txtLong.Text = "";
        }
    }
}
