using Dapper;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        void Create(T item);
        IEnumerable<T> ReadAll();
        T ReadById(string id);
        void Update(T item);
        void Delete(string id);
    }
}
