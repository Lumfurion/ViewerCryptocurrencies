using ViewerCryptocurrencies.UI.Services;

namespace ViewerCryptocurrencies.UI.Commands
{
    /// <summary>
    /// The command that will pass the model to the CurrentViewModel.
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigateService;

        public NavigateCommand(INavigationService navigateService)
        {
            _navigateService = navigateService;
        }

        public override void Execute(object parameter)
        {
            _navigateService.Navigate();
        }


    }

}
