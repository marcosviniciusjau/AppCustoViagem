using AppCustoViagem.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaViagem : ContentPage
    {
        public NovaViagem()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaPedagio());
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Viagem v = new Viagem
                {
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Consumo = Convert.ToDouble(txt_km_litro.Text),
                    Preco_Combustivel = Convert.ToDecimal(txt_preco_combustivel.Text),
                    Localizacao = txt_localizacao.Text,
                    Preco_Pedagio = Convert.ToDecimal(txt_preco_pedagio.Text)
                };

                App.ListaViagens.Add(v);

                //PropriedadesApp.ListaPedagios.Add(p);

                await DisplayAlert("Deu Certo!", "Viagem Adicionada", "OK");

                await Navigation.PopAsync();

                _ = Navigation.PushAsync(new ListaViagens());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }


        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            double distancia = Convert.ToDouble(txt_distancia.Text);
            double preco_combustivel = Convert.ToDouble(txt_preco_combustivel.Text);
            double km_litro = Convert.ToDouble(txt_km_litro.Text);

            double custo_combustivel = (distancia / km_litro) * preco_combustivel;

            // Calculando valor do pedágio com LINQ
            double custo_pedagio = (double)App.ListaPedagios.Sum(i => i.Valor);

            // Custo total da viagem
            double custo_viagem = custo_combustivel + custo_pedagio;

            // Mostrando o resultado
            spn_custo_combustivel.Text = custo_combustivel.ToString("C");
            spn_custo_pedagios.Text = custo_pedagio.ToString("C");
            lbl_custo_viagem.Text = custo_viagem.ToString("C");
        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaViagens());
        }
    }
}