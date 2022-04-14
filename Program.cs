using System;
using System.Windows.Forms;

namespace GraphSample
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Dll.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Dll.Uninitialize();
        }
    }
}
