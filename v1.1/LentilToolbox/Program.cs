using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LentilToolbox
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Shaftwin oShaftwin =new Shaftwin();
            oShaftwin.initialize(oShaftwin);
            Application.Run(oShaftwin);
        }
    }
}
