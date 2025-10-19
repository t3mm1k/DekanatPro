using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
    

namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Student>
    {
        private readonly string _connectionString;

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
                string sql = @"INSERT INTO Students (StudentNumber, Name, Speciality, [Group])
                               VALUES (@StudentNumber, @Name, @Speciality, @Group)";
                conn.Execute(sql, new
                {
                    item.StudentNumber,
                    item.Name,
                    item.Speciality,
                    Group = item.Group
                });
            }
        }

        public IEnumerable<Student> ReadAll()
        {
            using (var conn = CreateConnection())
            {
                string sql = "SELECT StudentNumber, Name, Speciality, [Group] FROM Students";
                return conn.Query<Student>(sql).ToList();
            }
        }

        public Student ReadById(string id)
        {
            using (var conn = CreateConnection())
            {
                string sql = "SELECT StudentNumber, Name, Speciality, [Group] FROM Students WHERE StudentNumber = @Id";
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
                               WHERE StudentNumber = @StudentNumber";
                conn.Execute(sql, new
                {
                    item.Name,
                    item.Speciality,
                    Group = item.Group,
                    item.StudentNumber
                });
            }
        }

        public void Delete(string id)
        {
            using (var conn = CreateConnection())
            {
                string sql = "DELETE FROM Students WHERE StudentNumber = @Id";
                conn.Execute(sql, new { Id = id });
            }
        }
    }
}
