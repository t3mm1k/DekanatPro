using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WindowsForm_View;
using Model;
using Shared;
using WinForms_View;

namespace Presentier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form2 view = new Form2();
            new StudentPresenter(view, new StudentModel());
            System.Windows.Forms.Application.Run(view);

        }
    }
}
