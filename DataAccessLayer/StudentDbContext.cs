using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("name=StudentDbContext")
        {
        }

        public StudentDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(s => s.Speciality)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(s => s.Group)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .ToTable("Students");

            base.OnModelCreating(modelBuilder);
        }
    }
}
