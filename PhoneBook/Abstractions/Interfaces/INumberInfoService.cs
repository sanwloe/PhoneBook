using DL.DataContext;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Abstractions.Interfaces
{
    public interface INumberInfoService
    {
        List<NumberInfo> GetNumbers();
        void Add(NumberInfo info);
        void Update(NumberInfo info);
        void Remove(NumberInfo info);
    }
}
