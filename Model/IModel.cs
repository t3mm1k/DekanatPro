using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModel<T> where T: class
    {
        event Action<IEnumerable<T>> DataChanged;
        void Delete(int id);
        void Insert(T item);
    }
}
