using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC1.Data;
using PC1.Properties;

namespace PC1;

internal static class Program
{
    public static string dbVar = @$"{Settings.Default.dailyFolder}\PC1db.sqlite";

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Copy user settings from previous application version if necessary
        if (Settings.Default.UpdateSettings)
        {
            Settings.Default.Upgrade();
            Settings.Default.UpdateSettings = false;
            Settings.Default.Save();
            Settings.Default.Reload();
        }
        if (string.IsNullOrEmpty(Settings.Default.dailyFolder))
        {
            Settings.Default.dailyFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Settings.Default.Save();
        }
        if (!File.Exists(dbVar)) SQLiteConnection.CreateFile(dbVar);

        var services = new ServiceCollection();

        ConfigureServices(services);

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var form1 = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form1);
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddLogging()
            .AddDbContext<DbContextDb>(options =>
                options.UseSqlite($"Filename={dbVar}" ??
                                  throw new InvalidOperationException("Connection string 'DbContext' not found.")));
        services.AddScoped<Form1>();
    }
}