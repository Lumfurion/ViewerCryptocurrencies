

using System.Windows;

namespace ViewerCryptocurrencies.UI.Commands
{
    /// <summary>
    /// Closes application
    /// </summary>
    public class CloseApplicationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (Application.Current is Application current)
            {
                current.Shutdown();
            }
        }
    }
}
