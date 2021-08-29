using System;

namespace WpfPracticalProject.Common
{
    public abstract class CloseableViewModelBase : ViewModelBase
    {
        public event EventHandler ClosingRequest;

        protected void OnClosingRequest()
        {
            if (ClosingRequest != null) ClosingRequest(this, EventArgs.Empty);
        }
    }
}