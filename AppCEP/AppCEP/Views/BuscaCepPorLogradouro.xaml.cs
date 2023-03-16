using AppCEP.Model;
using AppCEP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaCepPorLogradouro : ContentPage
    {
        public BuscaCepPorLogradouro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                List<Cep> arr_ceps = await DataService.GetCepsByLogradouro(upper(txt_logradouro.Text));

                lst_ceps.ItemsSource = arr_ceps;

                //if (arr_ceps. = )
                //{
                //    await DisplayAlert("Erro!", "Nenhuma rua encontrada!", "OK");
                //}
            } catch (Exception ex)
            {
                await DisplayAlert("Erro!", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
        public static string upper(string s)
        {
            return s[0].ToString().ToUpper() + s.Substring(1);
        }
    }
}