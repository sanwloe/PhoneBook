using CommunityToolkit.Mvvm.Input;
using PhoneBook.Abstractions;
using PhoneBook.Abstractions.Interfaces;
using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace PhoneBook.ViewModel
{
    public class NumberAddPageViewModel : ViewModelBase
    {
        public NumberAddPageViewModel(INumberInfoService service)
        {
            _numberInfoService = service;
            AddNewPhoneInfoCommand = new(AddNewPhoneInfo!);
            NumberInfo = new();
        }
        private INumberInfoService _numberInfoService;
        public RelayCommand AddNewPhoneInfoCommand { get; set; }
        public NumberInfo NumberInfo { get => GetValue<NumberInfo>(); set => SetValue(value); }
        public NavigationService NavigationService { get; set; } = null!;
        private void AddNewPhoneInfo()
        {
            if(NumberInfo.IsValid())
            {
                _numberInfoService.Add(NumberInfo);
                NumberInfo = new();
                GoBack();
            }
        }
        public void GoBack()
        {
            if(NavigationService!=null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
