using System;
using AppCustoViagem.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Threading;

namespace AppCustoViagem.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class EditarViagem : ContentPage
	{
		public EditarViagem ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            double distancia = Convert.ToDouble(txt_distancia.Text);
            double preco_combustivel = Convert.ToDouble(txt_preco_combustivel.Text);
            double km_litro = Convert.ToDouble(txt_km_litro.Text);

            double custo_combustivel = distancia / km_litro * preco_combustivel;

            // Calculando valor do pedágio com LINQ
            double custo_pedagio = (double)App.ListaPedagios.Sum(i => i.Valor);

            // Custo total da viagem
            double custo_viagem = custo_combustivel + custo_pedagio;

            // Mostrando o resultado
            spn_custo_combustivel.Text = custo_combustivel.ToString("C");
            spn_custo_pedagios.Text = custo_pedagio.ToString("C");
            lbl_custo_viagem.Text = custo_viagem.ToString("C");
        }  
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Obtém qual foi o Produto anexado no BindingContext da página no momento que ela foi criada e enviada para navegação.
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            try
            {
                Viagem viagem_anexada = BindingContext as Viagem;

                //Preencherá a Model com os valores dos entrys
                Viagem v = new Viagem
                {
                    Id = viagem_anexada.Id,
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Consumo = Convert.ToDouble(txt_km_litro.Text),
                    Preco = Convert.ToDecimal(txt_preco_combustivel.Text)
                };

                //Aqui atualizará o banco de dados com as novas informações da model
                App.Database.UpdateViagem(v);

                DisplayAlert("Sucesso!", "Viagem Editada", "OK");

                Navigation.PushAsync(new ListaViagens());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }

       
        }
    }
    
}
