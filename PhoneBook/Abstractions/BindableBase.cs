using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Abstractions
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Dictionary<string,object> _properties = [];

        public T GetValue<T>([CallerMemberName] string? propertyName = null)
        {
            _properties.TryGetValue(propertyName ?? string.Empty, out var value); 
            return (T)value!;
        }
        public void SetValue(object value, [CallerMemberName] string? propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;
            _properties[propertyName] = value;
            OnPropertyChanged(propertyName);
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
