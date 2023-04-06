using System;
using AppCEP.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCEP.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCEP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BairrosPorCidade : ContentPage
    {
        ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();

        ObservableCollection<Bairro> lista_bairros = new ObservableCollection<Bairro>();

        public BairrosPorCidade()
        {
            InitializeComponent();

            pck_cidade.ItemsSource = lista_cidades;

            lst_bairros.ItemsSource = lista_bairros;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                simcarregando();

                Picker disparador = sender as Picker;

                simcarregando();

                string estado_selecionado = disparador.SelectedItem as string;

                List<Cidade> arr_cidades = await DataService.GetCidadesByUf(estado_selecionado);

                lista_cidades.Clear();

                arr_cidades.ForEach(i => lista_cidades.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally { naocarregando(); }
        }

        private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                simcarregando();

                lista_bairros.Clear();

                Picker disparador = sender as Picker;

                int id_cidade = disparador.SelectedIndex;

                List<Bairro> arr_bairros = await DataService.GetBairrosByIdCidade(id_cidade); ;

                arr_bairros.ForEach(item => lista_bairros.Add(item));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally { naocarregando(); }
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