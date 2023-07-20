using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_3Grupo5
{
    public partial class MainPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;

        public MainPage()
        {
            InitializeComponent();
        }

        public String Getimage64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    String Base64 = Convert.ToBase64String(fotobyte);

                    return Base64;
                }
            }

            return null;
        }

        public byte[] GetimageBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }
            }

            return null;
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MYAPP",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                Imagen.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descripcion.Text) || photo == null)
            {
                await DisplayAlert("Error", "Por favor ingrese una descripción y tome una foto antes de guardar.", "OK");
                return;
            }

            var foto = new Models.Fotografia
            {
                Descripcion = descripcion.Text,
                Imagen = GetimageBytes()
            };

            if (await App.Instancia.AddEmple(foto) > 0)
            {
                await DisplayAlert("Aviso", "Registro exitoso.", "OK");

                // Limpiar los campos después de guardar la fotografía
                descripcion.Text = string.Empty;
                Imagen.Source = null;
                photo = null;
            }
            else
            {
                await DisplayAlert("Aviso", "Ha ocurrido un error al guardar el registro", "OK");
            }
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageList());
        }
    }
}
