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

    public Viagem(string origem, string destino, double distancia, double consumo, decimal precoCombustivel, string localizacao, decimal precoPedagio)
    {
        if (string.IsNullOrEmpty(origem) || string.IsNullOrEmpty(destino) || distancia <= 0 || consumo <= 0 || precoCombustivel <= 0 || string.IsNullOrEmpty(localizacao) || precoPedagio <= 0)
        {
            throw new ArgumentException("Argumentos inválidos para criar uma viagem.");
        }

        Origem = origem;
        Destino = destino;
        Distancia = distancia;
        Consumo = consumo;
        Preco_Combustivel = precoCombustivel;
        Localizacao = localizacao;
        Preco_Pedagio = precoPedagio;
    }

}
