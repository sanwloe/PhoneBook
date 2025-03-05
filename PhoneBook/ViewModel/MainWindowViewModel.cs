using CommunityToolkit.Mvvm.Input;
using Model.Models;
using PhoneBook.Abstractions;
using PhoneBook.Abstractions.Interfaces;
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
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace PhoneBook.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(ThemeService service)
        {
            ThemeService = service;
            DisplayNumberAddPageCommand = new(DisplayNumberAddPage);
        }
        public ThemeService ThemeService { get => GetValue<ThemeService>(); set => SetValue(value); }
        public RelayCommand DisplayNumberAddPageCommand { get; set; }
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
                    NumberAddPage.Do<NumberAddPageViewModel>((vm) =>
                    {
                        vm.NavigationService = NavigationService;
                    });
                }
            }
        }
        private NumbersPage NumbersPage { get; set; } = new();
        private NumberAddPage NumberAddPage { get; set; } = new();
        public void ShowNumbers()
        {
            NavigationService.Navigate(NumbersPage);
        }
        private void DisplayNumberAddPage()
        {
            NavigationService.Navigate(NumberAddPage);
        }
    }
}
