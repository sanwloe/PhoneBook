using DL.DataContext;
using PhoneBook.Abstractions.Interfaces;
using PhoneBook.Extensions;
using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses = Model.Models;

namespace PhoneBook.Services
{
    public class NumberInfoService : INumberInfoService
    {
        private PBDataContext _dataContext { get; }
        public NumberInfoService(PBDataContext context)
        {
            _dataContext = context;
        }
        public List<NumberInfo> GetNumbers()
        {
            return _dataContext.Numbers.Map().ToList();
        }
        public void Add(NumberInfo info)
        {
            _dataContext.Numbers.Add(info.Map());
            _dataContext.SaveChanges();
        }
        public void Update(NumberInfo info) 
        {
            _dataContext.Update(info.Map());
            _dataContext.SaveChanges();
        }  
        public void Remove(NumberInfo info)
        {
            _dataContext.Remove(info.Map());
            _dataContext.SaveChanges();
        }
    }
}
