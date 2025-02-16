using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBook.Extensions
{
    public static class ViewModelExtensions
    {
        public static void Do<TViewModel>(this FrameworkElement e,Action<TViewModel> action)
        {
            if (e.DataContext is TViewModel viewModel)
            {
                action.Invoke(viewModel);
            }
            else
            {
                foreach (var item in e.Resources.Values)
                {
                    if(item is TViewModel vm)
                    {
                        action(vm);
                    }
                }
            }
        }
    }
}
