using SQLite;
using System;

public class Viagem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Origem { get; set; }

    public string Destino { get; set; }

    public double Distancia { get; set; }

    public double Consumo { get; set; }

    public decimal Preco_Combustivel { get; set; }

    public string Localizacao { get; set; }

    public decimal Preco_Pedagio { get; set; }

  
}
