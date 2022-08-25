using System;
using ViewerCryptocurrencies.Models;
using ViewerCryptocurrencies.UI.ViewModels.Interfaces;

namespace ViewerCryptocurrencies.UI.ViewModels
{
    class SetingsViewModel : NotifyObject, ISetingsViewModel
    {
        #region IDisposable Members
        public event EventHandler? Disposed;
        private bool _disposed = false;

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void OnDispose(EventArgs e)
        {
            Disposed?.Invoke(this, e);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                OnDispose(EventArgs.Empty);
                _disposed = true;
            }

        }
        #endregion 
    }
}
