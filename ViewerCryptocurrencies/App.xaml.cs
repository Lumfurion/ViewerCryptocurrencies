using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ViewerCryptocurrencies.UI.Services;
using ViewerCryptocurrencies.UI.Stores;
using ViewerCryptocurrencies.UI.ViewModels;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
       
        public App()
        {
            // Contents of the container depending on what services can be registered
            IServiceCollection services = new ServiceCollection();

            //Registering Stores with Dependency Injection.
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            services.AddSingleton(CreateLayoutNavigationService);

            //Registering ViewModels with Dependency Injection.
            services.AddSingleton<IMainViewModel, MainWindowViewModel>();
            services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<IMainViewModel>() });
            services.AddTransient<ILayoutViewModel, LayoutViewModel>(s => new LayoutViewModel());

            _serviceProvider = services.BuildServiceProvider();
            
        }

        #region Events
        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>(); // Getting mainWindow from navigation service
            MainWindow.Show();
            
            base.OnStartup(e);
        }

        #endregion





        #region Creating objects
        /// <summary>
        /// Navigation to page Layout 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private INavigationService CreateLayoutNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ILayoutViewModel>(navigationStore: serviceProvider.GetRequiredService<NavigationStore>(),
                viewModel: serviceProvider.GetRequiredService<ILayoutViewModel>());
        }


        #endregion


    }
}
