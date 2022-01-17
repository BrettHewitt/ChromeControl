using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChromeControl.TestApp.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelState ViewModelState
        {
            get;
            private set;
        } = ViewModelState.Clean;

        protected void NotifyPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void MarkAsDirty()
        {
            ViewModelState = ViewModelState.Dirty;
        }

        protected void MarkAsDirtyAndNotifyPropertyChange([CallerMemberName]string propertyName = "")
        {
            ViewModelState = ViewModelState.Dirty;
            NotifyPropertyChanged(propertyName);
        }

        protected void Initialise()
        {
            ViewModelState = ViewModelState.Clean;
        }
    }

    public enum ViewModelState
    {
        Clean,
        Dirty,
    }
}
