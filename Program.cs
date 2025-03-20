using System;
using System.Windows.Forms;

namespace loginValido
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SistemaLogin());


        }
    }
}
