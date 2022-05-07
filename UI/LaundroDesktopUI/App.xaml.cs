using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using LaundroDesktopUI.Services;
using LaundroDesktopUI.Stores;
using LaundroDesktopUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace LaundroDesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<NewSaleViewModel> navigationService = _serviceProvider.GetRequiredService<NavigationService<NewSaleViewModel>>();
            navigationService.Navigate();

            MainWindow = _serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {

            //services.AddSingleton<NewSaleViewModel>();
            //services.AddSingleton<CleanViewModel>();
            //services.AddTransient((s) => CreateNewSaleListingViewModel(s));
            services.AddSingleton<NewSaleViewModel>();
            services.AddSingleton<Func<NewSaleViewModel>>( (s)=> () => s.GetRequiredService<NewSaleViewModel>());
            services.AddSingleton<NavigationService<NewSaleViewModel>>();

            services.AddSingleton<CleanViewModel>();
            services.AddSingleton<Func<CleanViewModel>>( (s)=> () => s.GetRequiredService<CleanViewModel>());
            services.AddSingleton<NavigationService<CleanViewModel>>();

            services.AddSingleton<ReadyViewModel>();
            services.AddSingleton<Func<ReadyViewModel>>((s) => () => s.GetRequiredService<ReadyViewModel>());
            services.AddSingleton<NavigationService<ReadyViewModel>>();



            services.AddSingleton<CustomerViewModel>();
            services.AddSingleton<SideBarViewModel>();
            services.AddSingleton<RegisterCustomerViewModel>();
            services.AddSingleton<PaymentSelectionViewModal>();
            services.AddSingleton<CashInputViewModel>();
            services.AddSingleton<CancelViewModel>();
            services.AddSingleton<SelectCustomerViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<SideBarViewModel>();
            services.AddSingleton<AddNewProductViewModel>();
            services.AddSingleton<ILoggedInUserModel, LoggedInUserModel>();
            //services.AddSingleton<EditItemViewModel>();

            services.AddSingleton<IAPIHelper, APIHelper>();
            services.AddSingleton<NavigationStore>();

            services.AddScoped<IProductEndpoint, ProductEndpoint>();
            services.AddScoped<ICustomerEndpoint, CustomerEndpoint>();
            services.AddScoped<IWdfEndpoint, WdfEndpoint>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }
        //private static NewSaleViewModel CreateNewSaleListingViewModel(IServiceProvider services)
        //{
        //    return NewSaleViewModel
        //}



    }

}
