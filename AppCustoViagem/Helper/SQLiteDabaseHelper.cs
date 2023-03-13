
using AppCustoViagem.Model;


using SQLite;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace AppCustoViagem.Helper
{

    public class SQLiteDatabaseHelper
    {

        readonly SQLiteAsyncConnection _conn;



        public SQLiteDatabaseHelper(string path)
        {

            _conn = new SQLiteAsyncConnection(path);

        
            _conn.CreateTableAsync<Viagem>().Wait();
        }




        public Task<int> InsertViagem(Viagem v)
        {
            return _conn.InsertAsync(v);
        }




        public Task<List<Viagem>> UpdateViagem(Viagem v)
        {
            string sql = "UPDATE Viagem SET Origem=?, Destino=?, Distancia=?, Consumo=?,Preco_Combustivel=?,Localizacao=?,Preco_Pedagio=? WHERE id= ? ";
            return _conn.QueryAsync<Viagem>(sql, v.Origem, v.Destino, v.Distancia, v.Consumo, v.Preco_Combustivel, v.Localizacao, v.Preco_Pedagio, v.Id); ;
        }



    

        public Task<List<Viagem>> GetAllRows()
        {
            return _conn.Table<Viagem>().ToListAsync();
        }


   
        public Task<int> DeleteV(int id)
        {

            return _conn.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }



    }
}