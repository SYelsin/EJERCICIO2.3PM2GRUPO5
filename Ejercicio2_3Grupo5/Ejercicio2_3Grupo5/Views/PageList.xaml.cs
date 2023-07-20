using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_3Grupo5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {
        public PageList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Listaemple.ItemsSource = await App.Instancia.GetAll();
        }
    }
}