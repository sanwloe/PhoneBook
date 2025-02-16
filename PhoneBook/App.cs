using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBook
{
    public partial class App : System.Windows.Application
    {
        public App(NumberInfoService service)
        {
            this.Resources.MergedDictionaries.Add(new()
            {
                Source = new Uri("Themes/Generic.xaml", UriKind.Relative)
            });
            //MessageBox.Show(service.GetNumbers().Count.ToString());
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
