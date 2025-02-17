using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses = Model.Models;
using UIClasses = PhoneBook.Model;

namespace PhoneBook.Extensions
{
    public static class MapExtensions
    {
        public static UIClasses.NumberInfo Map(this BaseClasses.NumberInfo info)
        {
            return Mappers.Mapper.Instance.Map<UIClasses.NumberInfo>(info);
        }
        public static BaseClasses.NumberInfo Map(this UIClasses.NumberInfo info)
        {
            return Mappers.Mapper.Instance.Map<BaseClasses.NumberInfo>(info);
        }
        public static IEnumerable<UIClasses.NumberInfo> Map(this IEnumerable<BaseClasses.NumberInfo> enumerable)
        {
            return Mappers.Mapper.Instance.Map<IEnumerable<UIClasses.NumberInfo>>(enumerable);
        }
        public static IEnumerable<BaseClasses.NumberInfo> Map(this IEnumerable<UIClasses.NumberInfo> enumerable)
        {
            return Mappers.Mapper.Instance.Map<IEnumerable<BaseClasses.NumberInfo>>(enumerable);
        }
    }
}
