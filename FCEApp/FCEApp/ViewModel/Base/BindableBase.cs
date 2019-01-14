using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FCEApp.ViewModel.Base
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        private string textHeader;

        public string TextHeader
        {
            get { return textHeader; }
            set
            {
                if (textHeader!=value)
                {
                    SetProperty(ref textHeader, value);
                    OnEventTextHeader();
                }               
            }
        }
        public BindableBase()
        {
            
        }

        private void OnEventTextHeader()
        {
            var upper = TextHeader.Substring(0, 1);
            var legth = TextHeader.Substring(1);
            string concat = upper.ToUpper() + legth;
            TextHeader = concat;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
