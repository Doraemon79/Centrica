using CentricaShops.Models;
using CentricaShops.Services;
using CentricaShops.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CentricaShops
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        private readonly GeneralDistrict _generalDistrict;
        public App()
        {
            _generalDistrict = new GeneralDistrict("Centrica Stores");

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    //services.AddTransient<ISalePersonProcessor, SalePersonProcessor>();
                    services.AddSingleton<IDistrictsAndSalesPeopleService, DistrictsAndSalesPeopleService>();
                    services.AddHttpClient("CentricaAPI",
                        client=>client.BaseAddress=new Uri("https://localhost:7235/api/SalePerson")
                        );
                     
                    services.AddSingleton((s) => new GeneralDistrict("Centrica Stores"));
                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });

                    services.AddSingleton<ShowDistrictViewModel>();
                    //services.AddSingleton<ShowDistrictViewModel>(s => new ShowDistrictViewModel());

                }).Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();


            startupForm.Show();

            //MainWindow = new MainWindow()
            //{
            //    DataContext = new MainViewModel()
            //};
            //MainWindow.Show();

            base.OnStartup(e);
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }

}
