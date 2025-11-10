using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Model;
    

namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Student>
    {
        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\t3mm1k\\projects\\AIS\\DekanatPro\\DataAccessLayer\\Database1.mdf;Integrated Security=True";

        public DapperRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString is null or empty", nameof(connectionString));

            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public void Create(Student item)
        {
            using (var conn = CreateConnection())
            {
                string sql = @"INSERT INTO Students (Name, Speciality, [Group])
                               VALUES (@Name, @Speciality, @Group);
                               SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = conn.QuerySingle<int>(sql, new
                {
                    item.Name,
                    item.Speciality,
                    Group = item.Group
                });
                item.Id = id;
            }
        }

        public IEnumerable<Student> ReadAll()
        {
            using (var conn = CreateConnection())
            {
                string sql = "SELECT Id, Name, Speciality, [Group] FROM Students";
                return conn.Query<Student>(sql).ToList();
            }
        }

        public Student ReadById(int id)
        {
            using (var conn = CreateConnection())
            {
                string sql = "SELECT Id, Name, Speciality, [Group] FROM Students WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Student>(sql, new { Id = id });
            }
        }

        public void Update(Student item)
        {
            using (var conn = CreateConnection())
            {
                string sql = @"UPDATE Students
                               SET Name = @Name,
                                   Speciality = @Speciality,
                                   [Group] = @Group
                               WHERE Id = @Id";
                conn.Execute(sql, new
                {
                    item.Id,
                    item.Name,
                    item.Speciality,
                    Group = item.Group
                });
            }
        }

        public void Delete(int id)
        {
            using (var conn = CreateConnection())
            {
                string sql = "DELETE FROM Students WHERE Id = @Id";
                conn.Execute(sql, new { Id = id });
            }
        }
    }
}
