using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_View
{
    public interface IView
    {
        event Action<EventArgs> AddDataEvent;
        event Action<int> DeleteDataEvent;
    }

}
