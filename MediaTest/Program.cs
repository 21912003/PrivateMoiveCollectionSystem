using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            long l = 3L * 1024L * 1024L * 1024L * 1024L;
            string x = l.ToString("#,###");
            
            System.Console.WriteLine(x);

            //实例化
            GuideForm guideForm = new GuideForm();
            //运行
            Application.Run(guideForm);
       
        }
    }
}
