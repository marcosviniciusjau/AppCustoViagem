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
    public partial class EditarPedagio : ContentPage
    {

        public EditarPedagio()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            // Obtém qual foi o Produto anexado no BindingContext da página no momento que ela foi criada e enviada para navegação.

            try
            {
                Pedagio pedagio_anexado = BindingContext as Pedagio;

                //Preencherá a Model com os valores dos entrys
                Pedagio p = new Pedagio
                {
                    Id = pedagio_anexado.Id,
                    Localizacao = txt_localizacao.Text,
                    Valor = Convert.ToDecimal(txt_preco.Text),
                };

                //Aqui atualizará o banco de dados com as novas informações da model
                 App.Database.Update(p);

                 DisplayAlert("Sucesso!", "Pedagio Editado", "OK");

                Navigation.PushAsync(new ListaPedagio());
            }
            catch (Exception ex)
            {
                 DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}