using System.Collections.Generic;

namespace ViewerCryptocurrencies.UI.Services
{
    /// <summary>
    /// Will unite several services
    /// </summary>
    public class CompositeNavigationService : INavigationService
    {   /// <summary>
        /// Collection of services
        /// </summary>
        private readonly IEnumerable<INavigationService> _navigationServices;

        public CompositeNavigationService(params INavigationService[] navigationServices)
        {
            _navigationServices = navigationServices;
        }

        public void Navigate()
        {
            //Iterating over all navigation services
            foreach (INavigationService navigationService in _navigationServices)
            {
                navigationService.Navigate();
            }
        }
    }
}
