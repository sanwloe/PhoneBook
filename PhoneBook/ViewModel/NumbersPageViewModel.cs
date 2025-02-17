using CommunityToolkit.Mvvm.Input;
using PhoneBook.Abstractions;
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
        public NumbersPageViewModel(NumberInfoService service)
        {
            _numberInfoService = service;
            OnMouseLeftDoubleClickNumberSelectedCommand = new(OnMouseLeftDoubleClickNumberSelected!);
            var items = _numberInfoService.GetNumbers();
            items.ForEach(Numbers.Add);
        }

        private NumberInfoService _numberInfoService;
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
        public RelayCommand<NumberInfo> OnMouseLeftDoubleClickNumberSelectedCommand { get; set; }
        public ObservableCollection<NumberInfo> Numbers { get; set; } = [];
        private NumberDetailsPage NumberDetailsPage { get; set; } = new();
        private void OnMouseLeftDoubleClickNumberSelected(NumberInfo info)
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
    }
}
