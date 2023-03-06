
using AppCustoViagem.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoPedagio : ContentPage
    {
        public NovoPedagio()
        {
            InitializeComponent();
        }

     

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Pedagio p = new Pedagio
                {
                    Localizacao = txt_localizacao.Text,
                    Valor = Convert.ToDecimal(txt_preco.Text)
                };

                App.ListaPedagios.Add(p);

                //PropriedadesApp.ListaPedagios.Add(p);

                 DisplayAlert("Deu Certo!", "Pedágio Adicionado", "OK");

                Navigation.PopAsync();



            }
            catch (Exception ex)
            {
                 DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }

}