using PhoneBook.Abstractions;
using PhoneBook.Abstractions.Interfaces;
using PhoneBook.Model;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace PhoneBook.ViewModel
{
    public class NumberDetailsPageViewModel : ViewModelBase
    {
        public NumberDetailsPageViewModel(INumberInfoService service)
        {
            _numberInfoService = service;
        }
        private INumberInfoService _numberInfoService;
        public NavigationService NavigationService { get; set; } = null!;
        public NumberInfo Number 
        { 
            get => GetValue<NumberInfo>();
            private set => SetValue(value); 
        }
        public void DisplayDetails(NumberInfo number)
        {
            Number = number;
        }
        public void GoBack()
        {
            if (NavigationService != null)
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }
    }
}
