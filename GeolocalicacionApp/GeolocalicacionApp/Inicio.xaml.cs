using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace GeolocalicacionApp
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

            //lblSubTitle.Style = Device.Styles.SubtitleStyle;
            //lblTitle.Style = Device.Styles.TitleStyle;
            //lblBody.Style = Device.Styles.BodyStyle;
            //lblCaption.Style = Device.Styles.CaptionStyle;
            //lblItemDetail.Style = Device.Styles.ListItemDetailTextStyle;
            //lblItemText.Style = Device.Styles.ListItemTextStyle;

            var estiloTitulo = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter {Property = Label.TextColorProperty, Value=Color.Yellow},
                    new Setter {Property = Label.FontSizeProperty, Value = 30},
                    new Setter {Property = Label.XAlignProperty, Value = TextAlignment.Center}
                }
            };

            lblTitle.Style = estiloTitulo;
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
