using CommunityToolkit.Mvvm.Input;
using PhoneBook.Abstractions;
using PhoneBook.Abstractions.Interfaces;
using PhoneBook.Extensions;
using PhoneBook.Model;
using PhoneBook.Services;
using PhoneBook.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace PhoneBook.ViewModel
{
    public class NumbersPageViewModel : ViewModelBase
    {
        ~NumbersPageViewModel() 
        {
            UnsubscribeNumberServiceEvents();
        }
        public NumbersPageViewModel(INumberInfoService service)
        {
            _numberInfoService = service;
            DisplayNumberInfoDetailsCommand = new(DisplayNumberInfoDetails!);
            DeleteNumberInfoCommand = new(DeleteNumberInfo!);
            EditNumberInfoCommand = new(EditNumberInfo!);
            var items = _numberInfoService.GetNumbers();
            items.ForEach(Numbers.Add);
            SubscribeNumberServiceEvents();
        }
        private INumberInfoService _numberInfoService;
        public NavigationService NavigationService 
        { 
            get => GetValue<NavigationService>();
            set
            {
                SetValue(value);
                NumberDetailsPage.Do<NumberDetailsPageViewModel>((vm) =>
                {
                    vm.NavigationService = value;
                });
            }
        }
        public RelayCommand<NumberInfo> DisplayNumberInfoDetailsCommand { get; set; }
        public RelayCommand<NumberInfo> EditNumberInfoCommand { get; set; }
        public RelayCommand<NumberInfo> DeleteNumberInfoCommand { get; set; }
        public ObservableCollection<NumberInfo> Numbers { get; set; } = [];
        private NumberDetailsPage NumberDetailsPage { get; set; } = new();
        private void DisplayNumberInfoDetails(NumberInfo info)
        {
            if(NavigationService!=null)
            {
                NumberDetailsPage.Do<NumberDetailsPageViewModel>((vm) =>
                {
                    vm.DisplayDetails(info);
                });
                NavigationService.Navigate(NumberDetailsPage);
            }
        }
        private NumberEditPage NumberEditPage { get; set; } = new();
        private void EditNumberInfo(NumberInfo numberInfo)
        {
            if(NavigationService!=null)
            {
                NumberEditPage.Do<NumberEditPageViewModel>((vm) =>
                {
                    vm.NumberInfo = numberInfo;
                    vm.NavigationService = NavigationService;
                });
                NavigationService.Navigate(NumberEditPage);
            }
        }
        private void DeleteNumberInfo(NumberInfo info)
        {
            _numberInfoService.Remove(info);
        }
        private void SubscribeNumberServiceEvents()
        {
            _numberInfoService.OnNumberInfoDeleted += _numberInfoService_OnNumberInfoDeleted;
            _numberInfoService.OnNumberInfoAdded += _numberInfoService_OnNumberInfoAdded;
        }
        private void UnsubscribeNumberServiceEvents()
        {
            _numberInfoService.OnNumberInfoDeleted += _numberInfoService_OnNumberInfoDeleted;
            _numberInfoService.OnNumberInfoAdded += _numberInfoService_OnNumberInfoAdded;
        }
        private void _numberInfoService_OnNumberInfoAdded(NumberInfo obj)
        {
            Numbers.Add(obj);
        }
        private void _numberInfoService_OnNumberInfoDeleted(NumberInfo obj)
        {
            Numbers.Remove(obj);
        }
    }
}
