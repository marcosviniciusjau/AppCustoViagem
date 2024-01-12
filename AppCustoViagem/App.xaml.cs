
using AppCustoViagem.View;
using Xamarin.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.ObjectModel;
using AppCustoViagem.Helper;
using System;


namespace AppCustoViagem
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper database;

        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    string path = Path.Combine(
                     Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                      "arquivo.db3"
                                     );
                    database = new SQLiteDatabaseHelper(path);
                }

                return database;
            }
        }


        public static ObservableCollection<Viagem> ListaViagens = new ObservableCollection<Viagem>();

        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            MainPage = new NavigationPage(new NovaViagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}