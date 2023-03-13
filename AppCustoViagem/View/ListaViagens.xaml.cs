using AppCustoViagem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaViagens : ContentPage
    {
        public ListaViagens()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovaViagem());
        }

        public string ParametroBusca { get; set; }

        public ICommand Buscar
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                 
                        List<Viagem> tmp = await App.Database.Search(ParametroBusca);

                     
                        tmp.ForEach(i => App.ListaViagens.Add(i));

                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }

                });
            }
        }

        protected override void OnAppearing()
        {
            try
            {
                ref_carregando.IsRefreshing = false;

                lst_viagens.ItemsSource = App.ListaViagens;
            

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
      
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem disparador = (MenuItem)sender;

            Viagem viagem_selecionada = (Viagem)disparador.BindingContext;

            bool confirmacao = await DisplayAlert("Tem certeza?",
                                                  "Excluir viagem " + viagem_selecionada.Origem + "?",
                                                  "Sim", "Não");
            if (confirmacao)
            {
                App.ListaViagens.Remove(viagem_selecionada);

            }
        }

        private void lst_viagens_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Forma contraída de definir o BindingContext da página EditarProduto como sendo o Produto que foi selecionado na ListView (item da ListView) e em seguida já redicionando na navegação.

            Navigation.PushAsync(new EditarViagem
            {
                BindingContext = (Viagem)e.SelectedItem
            });
        }
    }
}