using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ExcelToDb
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                System.Windows.Forms.Application.Run(new System.Windows.Forms.Form());
            }
            catch(ApplicationException ex)
            {
                
            }
        }
    }
}
