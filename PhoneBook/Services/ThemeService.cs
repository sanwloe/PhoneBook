using CommunityToolkit.Mvvm.Input;
using ModernWpf;
using PhoneBook.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class ThemeService : BindableBase
    {
        private ThemeManager ThemeManager { get; set; }
        public ThemeService()
        {
            SetLightThemeCommand = new(SetLightTheme);
            SetDarkThemeCommand = new(SetDarkTheme);
            ThemeManager = ModernWpf.ThemeManager.Current;
            CurrentTheme = ThemeManager.ActualApplicationTheme;
        }
        public RelayCommand SetLightThemeCommand { get; set; }
        public RelayCommand SetDarkThemeCommand { get; set; }
        public ApplicationTheme CurrentTheme 
        { 
            get => GetValue<ApplicationTheme>();
            set
            {
                SetValue(value);
                ThemeManager.ApplicationTheme = value;
            }
        }
        private void SetLightTheme()
        {
            CurrentTheme = ApplicationTheme.Light;
        }
        private void SetDarkTheme()
        {
            CurrentTheme = ApplicationTheme.Dark;
        }
    }
    
}
