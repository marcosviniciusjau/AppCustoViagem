using SQLite;
using System;
using System.Collections.Generic;

namespace AppCustoViagem.Model
{
    public class Viagem
    {
        string _origem;
        string _destino;
        double _distancia;
        double _consumo;
        decimal _preco_combustivel;
        string _localizacao;
        decimal _preco_pedagio;

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Origem
        {
            get => _origem;
            set
            {
                if (value == null)
                    throw new Exception("Origem inválida");

                _origem = value;
            }
        }

        public string Destino
        {
            get => _destino;
            set
            {
                if (value == null)
                    throw new Exception("Destino inválido");

                _destino = value;
            }
        }

        public double Distancia
        {
            get
            {
                return _distancia;
            }


            set
            {
                //double val;

                if (!double.TryParse(value.ToString(), out _distancia))
                    _distancia = 0.0;

                if (value == 0)
                    throw new Exception("Distância inválida");

                _distancia = value;
            }
        }

        public double Consumo
        {
            get
            {
                return _consumo;
            }


            set
            {
                //double val;

                if (!double.TryParse(value.ToString(), out _consumo))
                    _consumo = 0.0;

                if (value == 0)
                    throw new Exception("Consumo inválido");

                _consumo = value;
            }
        }

        public decimal Preco_Combustivel
        {
            get
            {
                return _preco_combustivel;
            }


            set
            {
                //double val;

                if (!decimal.TryParse(value.ToString(), out _preco_combustivel))
                    _preco_combustivel = 0;

                if (value == 0)
                    throw new Exception("Preço do Combustível inválido");

                _preco_combustivel = value;
            }
        }

        public string Localizacao
        {
            get => _localizacao;
            set
            {
                if (value == null)
                    throw new Exception("Local inválido");

                _localizacao = value;
            }
        }
        public decimal Preco_Pedagio
        {
            get
            {
                return _preco_pedagio;
            }


            set
            {
                //double val;

                if (!decimal.TryParse(value.ToString(), out _preco_pedagio))
                    _preco_pedagio = 0;

                if (value == 0)
                    throw new Exception("Preço do Pedágio inválido");

                _preco_pedagio = value;
            }
        }
    }
}
