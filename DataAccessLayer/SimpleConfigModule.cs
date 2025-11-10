using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class SimpleConfigModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<EntityRepository>().InSingletonScope();
        }
    }
}
