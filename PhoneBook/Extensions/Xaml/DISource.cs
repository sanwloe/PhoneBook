using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace PhoneBook.Extensions.Xaml
{
    public class DISource : MarkupExtension
    {
        public static IServiceProvider ServiceProvider { get; set; } = null!;
        public Type Type { get; set; } = null!;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if(ServiceProvider == null)
            {
                throw new NullReferenceException(nameof(ServiceProvider));
            }
            if(Type == null)
            {
                throw new NullReferenceException(nameof(Type));
            }
            return ActivatorUtilities.CreateInstance(ServiceProvider, Type);
        }
    }
}
