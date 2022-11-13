using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC1.Data;

namespace PC1
{
    static class Program
    {
        public static string dbVar = @$"{Properties.Settings.Default.dailyFolder}\PC1db.sqlite";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging()
                     .AddDbContext<DbContextDb>(options =>
                options.UseSqlite($"Filename={dbVar}" ?? throw new InvalidOperationException("Connection string 'DbContext' not found.")));
            services.AddScoped<Form1>();
        }
    }
}
