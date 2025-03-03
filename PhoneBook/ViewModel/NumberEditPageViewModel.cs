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
    public class NumberEditPageViewModel : ViewModelBase
    {
        public NumberEditPageViewModel(INumberInfoService service) 
        {
            ApplyEditsCommand = new(Save!);
            _numberInfoService = service;
        }
        private INumberInfoService _numberInfoService;
        public NumberInfo NumberInfo { get => GetValue<NumberInfo>(); set => SetValue(value); }
        public RelayCommand ApplyEditsCommand { get => GetValue<RelayCommand>(); set => SetValue(value); }
        public NavigationService NavigationService { get; set; } = null!;
        private void Save()
        {
            _numberInfoService.Update(NumberInfo);
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
