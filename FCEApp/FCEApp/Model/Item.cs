using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using FCEApp.Annotations;

namespace FCEApp.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }

        public Category Category { get; set; }
    }
    public class Category : INotifyPropertyChanged
    {
        private string _imageName;
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
