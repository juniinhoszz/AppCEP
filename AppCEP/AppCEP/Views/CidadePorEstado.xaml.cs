using AppCEP.Model;
using AppCEP.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CidadePorEstado : ContentPage
    {
        ObservableCollection<Cidade> cidades = new ObservableCollection<Cidade>();
        public CidadePorEstado()
        {
            InitializeComponent();
            lst_cidade.ItemsSource = cidades;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                simcarregando();

                Picker disparador = (Picker)sender;

                string uf = disparador.SelectedItem as string;

                List<Cidade> lista_cidade = await DataService.GetCidadesByUf(uf);

                cidades.Clear();

                lista_cidade.ForEach(i => cidades.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                naocarregando();
            }
        }

        public void simcarregando()
        {
            carregando.IsEnabled = true;
            carregando.IsRunning = true;
        }
        public void naocarregando()
        {
            carregando.IsEnabled = false;
            carregando.IsRunning = false;
        }
    }
    
}