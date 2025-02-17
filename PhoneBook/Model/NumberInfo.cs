using PhoneBook.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model
{
    public class NumberInfo : BindableBase
    {
        public string Number { get => GetValue<string>(); set => SetValue(value); } 
        public string FirstName { get => GetValue<string>(); set => SetValue(value); }
        public string LastName { get => GetValue<string>(); set => SetValue(value); }
        public string FullName { get => GetValue<string>(); set => SetValue(value); }
        public DateTimeOffset DateOfRegistration 
        { 
            get => GetValue<DateTimeOffset>();
            set
            {
                SetValue(value);
                OnPropertyChanged(nameof(DateOfRegStr));
            }
        }
        public DateTimeOffset LastUpdateDate 
        { 
            get => GetValue<DateTimeOffset>();
            set
            {
                SetValue(value);
                OnPropertyChanged(nameof(LastUpdateDateStr));
            }
        }
        public string Description { get; set; } = string.Empty;
        public string DateOfRegStr { get => DateOfRegistration.DateTime.ToLocalTime().ToString(); }
        public string LastUpdateDateStr { get => LastUpdateDate.DateTime.ToLocalTime().ToString(); }
    }
}
