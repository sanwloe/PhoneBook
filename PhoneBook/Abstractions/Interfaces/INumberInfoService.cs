using DL.DataContext;
using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Abstractions.Interfaces
{
    public interface INumberInfoService
    {
        event Action<NumberInfo> OnNumberInfoAdded;
        event Action<NumberInfo> OnNumberInfoChanged;
        event Action<NumberInfo> OnNumberInfoDeleted;
        List<NumberInfo> GetNumbers();
        void Add(NumberInfo info);
        void Update(NumberInfo info);
        void Remove(NumberInfo info);
    }
}
