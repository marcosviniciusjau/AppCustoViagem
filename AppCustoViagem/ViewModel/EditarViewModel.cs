using System.ComponentModel;
using Xamarin.Forms;

namespace AppCustoViagem.ViewModel
{
    public class EditarViagemViewModel : INotifyPropertyChanged
    {
        private string _origem;
        public string Origem
        {
            get => _origem;
            set
            {
                if (_origem != value)
                {
                    _origem = value;
                    OnPropertyChanged(nameof(Origem));
                }
            }
        }

        // Outras propriedades e lógica da ViewModel

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
