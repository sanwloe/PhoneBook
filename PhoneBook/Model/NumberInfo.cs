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
        public NumberInfo()
        {
            Number = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            FullName = string.Empty;
            Description = string.Empty;
            DateOfRegistration = DateTimeOffset.Now;
            LastUpdateDate = DateTimeOffset.Now;
        }
        public string Number { get => GetValue<string>(); set => SetValue(value); } 
        public string FirstName 
        {
            get => GetValue<string>();
            set
            {
                SetValue(value);
                UpdateFullName();
            }
        }
        public string LastName 
        { 
            get => GetValue<string>();
            set
            {
                SetValue(value);
                UpdateFullName();
            }
        }
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
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Number);
        }
        private void UpdateFullName()
        {
            if(!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                FullName = $"{FirstName} {LastName}";
            }
        }
    }
}
