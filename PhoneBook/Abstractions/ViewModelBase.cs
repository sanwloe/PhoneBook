using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PhoneBook.Abstractions
{
    public abstract class ViewModelBase : BindableBase
    {
        public Dispatcher Dispatcher { get; set; }
        protected ViewModelBase()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
        }
    }
}
