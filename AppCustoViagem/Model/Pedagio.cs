using SQLite;

namespace AppCustoViagem.Model
{
    public class Pedagio
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public decimal Valor { get; set; }
    }
}
