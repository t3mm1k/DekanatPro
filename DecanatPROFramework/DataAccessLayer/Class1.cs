using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Student student = new Student(new EntityRepository<Student>());
            student.
        }
    }
}
