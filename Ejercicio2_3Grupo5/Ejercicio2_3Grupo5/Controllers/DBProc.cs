using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Ejercicio2_3Grupo5.Models;

namespace Ejercicio2_3Grupo5.Controllers
{
    public class DBProc
    {
        readonly SQLiteAsyncConnection _connection;
        public DBProc() { }
        public DBProc(string dbpath) 
        { 
            _connection = new SQLiteAsyncConnection(dbpath);
            /*Crear todos mis objetos de base de datos: tablas*/
            _connection.CreateTableAsync<Fotografia>().Wait();
        }
        /*Crear el CRUD de BD*/
        //Create
        public Task<int> AddEmple(Fotografia fotografias) 
        {
            if (fotografias.Id == 0)
            {
                return _connection.InsertAsync(fotografias);
            }
            else 
            { 
                return _connection.UpdateAsync(fotografias);
            }
        }
        
        //Read
        public Task<List<Fotografia>> GetAll() 
        { 
            return _connection.Table<Fotografia>().ToListAsync();
        }

        public Task<Fotografia> GetById(int id) 
        { 
            return _connection.Table<Fotografia>()
                .Where(i=>i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Delete
        public Task<int> DeleteEmple(Fotografia fotografias)
        {
           return _connection.DeleteAsync(fotografias);
        }
    }
}
