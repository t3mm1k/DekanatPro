using System;
using System.Configuration;
using Model;

namespace DataAccessLayer
{
    public enum RepositoryType
    {
        Dapper,
        EntityFramework
    }

    public static class RepositoryFactory
    {
        public static IRepository<Student> CreateRepository(string connectionString = null)
        {
            // Получаем тип репозитория из конфигурации
            var repositoryTypeConfig = ConfigurationManager.AppSettings["RepositoryType"];
            RepositoryType repositoryType;
            
            if (!Enum.TryParse(repositoryTypeConfig, out repositoryType))
            {
                // По умолчанию используем Dapper
                repositoryType = RepositoryType.Dapper;
            }

            // Если строка подключения не указана, берем из конфигурации
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings["StudentDbContext"]?.ConnectionString;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found in configuration");
            }

            switch (repositoryType)
            {
                case RepositoryType.Dapper:
                    return new DapperRepository(connectionString);
                case RepositoryType.EntityFramework:
                    return new EntityRepository(connectionString);
                default:
                    throw new ArgumentException($"Unsupported repository type: {repositoryType}");
            }
        }
    }
}
