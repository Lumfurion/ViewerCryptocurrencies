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
            Initstores(services);

           
            //Registering ViewModels with Dependency Injection.
            services.AddTransient<IHomeViewModel, HomeViewModel>();

            services.AddTransient<IShowCourseViewModel, ShowCourseViewModel>(s => new ShowCourseViewModel(
             CreateInfoCryptocurrencyNavigationService(s), s.GetRequiredService<MarketStore>()
              ));

            services.AddTransient<ISetingsViewModel, SetingsViewModel>();
            services.AddSingleton<IMainViewModel, MainWindowViewModel>();
            services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<IMainViewModel>() });
            services.AddTransient<ILayoutViewModel, LayoutViewModel>(CreateLayoutViewModel);
           
            services.AddTransient<ISideMenuViewModel, SideMenuViewModel>(CreateSideMenuViewModel);
            services.AddSingleton(CreateLayoutNavigationService);

            //Popup
            services.AddTransient<IInfoCryptocurrencyViewModel, InfoCryptocurrencyViewModel>(s => new InfoCryptocurrencyViewModel(
               s.GetRequiredService<MarketStore>(),
               s.GetRequiredService<CloseModalNavigationService>()
               ));

            _serviceProvider = services.BuildServiceProvider();

        }

        private static void Initstores(IServiceCollection services)
        {
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<CloseModalNavigationService>();
            services.AddSingleton<MarketStore>();
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

        #region Navigation
        
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


        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<IHomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<IHomeViewModel>,
                serviceProvider.GetRequiredService<ISideMenuViewModel>
            );
        }


        

        private INavigationService CreateShowCourseNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<IShowCourseViewModel>(
                  serviceProvider.GetRequiredService<NavigationStore>(),
                  serviceProvider.GetRequiredService<IShowCourseViewModel>,
                  serviceProvider.GetRequiredService<ISideMenuViewModel>
              );
        }


        private INavigationService CreateSetingsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ISetingsViewModel>(
                 serviceProvider.GetRequiredService<NavigationStore>(),
                 serviceProvider.GetRequiredService<ISetingsViewModel>,
                 serviceProvider.GetRequiredService<ISideMenuViewModel>
             );
        }


        private INavigationService CreateInfoCryptocurrencyNavigationService(IServiceProvider serviceProvider)
        {
          
            return new ModalNavigationService<IInfoCryptocurrencyViewModel>(
               serviceProvider.GetRequiredService<ModalNavigationStore>(),
               () => serviceProvider.GetRequiredService<IInfoCryptocurrencyViewModel>());
        }

        #endregion

        private LayoutViewModel CreateLayoutViewModel(IServiceProvider serviceProvider)
        {
            return new LayoutViewModel(
                CreateSideMenuViewModel(serviceProvider),
                serviceProvider.GetRequiredService<IHomeViewModel>()
            );
        }

        private SideMenuViewModel CreateSideMenuViewModel(IServiceProvider serviceProvider)
        {
            return new SideMenuViewModel(
                
                CreateHomeNavigationService(serviceProvider),
                CreateShowCourseNavigationService(serviceProvider),
                CreateSetingsNavigationService(serviceProvider)
                
            );
        }

        

        #endregion


    }
}
