﻿using AppCustoViagem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        protected override void OnAppearing()
        {
            try
            {
                lst_viagens.ItemsSource = App.ListaViagens;
                ref_carregando.IsRefreshing = false;

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