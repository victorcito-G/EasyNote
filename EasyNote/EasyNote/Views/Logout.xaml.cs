using EasyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyNote.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("users");
            Preferences.Remove("pass");
            Preferences.Remove("Remember");
            Preferences.Set("Remember", true);
            await Navigation.PushModalAsync(new LoginPage());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();


            String oauthToken = await SecureStorage.GetAsync("Usuario");

            Correo nombe = new Correo
            {
                usuario = oauthToken
            };

            BindingContext = nombe;


        }
    }
}