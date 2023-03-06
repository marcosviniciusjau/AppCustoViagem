
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

            _conn.CreateTableAsync<Pedagio>().Wait();
            _conn.CreateTableAsync<Viagem>().Wait();
        }


      
        public Task<int> Insert(Pedagio p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<int> InsertViagem(Viagem v)
        {
            return _conn.InsertAsync(v);
        }



        public Task<List<Pedagio>> Update(Pedagio p)
        {
            string sql = "UPDATE Pedagio SET Localizacao=?, Valor=? WHERE id= ? ";
            return _conn.QueryAsync<Pedagio>(sql, p.Localizacao, p.Valor, p.Id);
        }

        public Task<List<Viagem>> UpdateViagem(Viagem v)
        {
            string sql = "UPDATE Viagem SET Origem=?, Destino=?, Distancia=?, Consumo=?,Preco=? WHERE id= ? ";
            return _conn.QueryAsync<Viagem>(sql, v.Origem, v.Destino, v.Distancia, v.Consumo, v.Preco, v.Id);
        }



        public Task<List<Pedagio>> GetAll()
        {
            return _conn.Table<Pedagio>().ToListAsync();
        }

        public Task<List<Viagem>> GetAllRows()
        {
            return _conn.Table<Viagem>().ToListAsync();
        }


        public Task<int> Delete(int id)
        {

            return _conn.Table<Pedagio>().DeleteAsync(i => i.Id == id);
        }

        public Task<int> DeleteV(int id)
        {

            return _conn.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }



    }
}