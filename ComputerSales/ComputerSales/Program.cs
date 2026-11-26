using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerSales
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = DependencyInjection.ConfigureServices();

            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }
    }
}