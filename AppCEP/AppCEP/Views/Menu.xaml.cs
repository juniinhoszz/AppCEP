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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buscar_cep_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.BuscaCepPorLogradouro());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void buscar_rua_bairros_Clicked(object sender, EventArgs e)
        {

        }

        private void buscar_cidade_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BairrosPorCidade());
        }
    }
}