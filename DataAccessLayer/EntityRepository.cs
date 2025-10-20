using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DataAccessLayer
{
    public class EntityRepository : IRepository<Student>
    {
        private readonly string _connectionString;

        public EntityRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString is null or empty", nameof(connectionString));

            _connectionString = connectionString;
        }

        public void Create(Student item)
        {
            using (var context = new StudentDbContext(_connectionString))
            {
                context.Students.Add(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<Student> ReadAll()
        {
            using (var context = new StudentDbContext(_connectionString))
            {
                return context.Students.ToList();
            }
        }

        public Student ReadById(string id)
        {
            using (var context = new StudentDbContext(_connectionString))
            {
                return context.Students.Find(id);
            }
        }

        public void Update(Student item)
        {
            using (var context = new StudentDbContext(_connectionString))
            {
                var existingStudent = context.Students.Find(item.StudentNumber);
                if (existingStudent != null)
                {
                    context.Entry(existingStudent).CurrentValues.SetValues(item);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(string id)
        {
            using (var context = new StudentDbContext(_connectionString))
            {
                var student = context.Students.Find(id);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
            }
        }
    }
}
