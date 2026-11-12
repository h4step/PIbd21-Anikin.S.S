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

            // 1. —оздаем и настраиваем наш контейнер зависимостей
            var serviceProvider = DependencyInjection.ConfigureServices();

            // 2. ƒостаем главную форму из контейнера (все репозитории внедр€тс€ автоматически)
            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            // 3. «апускаем приложение
            Application.Run(mainForm);
        }
    }
}