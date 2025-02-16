using CommunityToolkit.Mvvm.Input;
using Model.Models;
using PhoneBook.Abstractions;
using PhoneBook.Extensions;
using PhoneBook.Services;
using PhoneBook.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PhoneBook.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            GoBackCommand = new RelayCommand(GoBack);
        }
        public RelayCommand GoBackCommand { get; set; }
        public NavigationService NavigationService 
        {
            get => GetValue<NavigationService>();
            set
            {
                SetValue(value);
                if(value!=null)
                {
                    ShowNumbers();
                    NumbersPage.Do<NumbersPageViewModel>((vm) =>
                    {
                        vm.NavigationService = NavigationService;
                    });
                }
            }
        }
        private NumbersPage NumbersPage { get; set; } = new();
        public void ShowNumbers()
        {
            NavigationService.Navigate(NumbersPage);
        }
        public void GoBack()
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
