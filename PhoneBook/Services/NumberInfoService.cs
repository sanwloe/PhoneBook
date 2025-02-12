using DL.DataContext;
using Model.Models;
using PhoneBook.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _dataContext.Numbers.ToList();
        }
        public void Add(NumberInfo info)
        {
            _dataContext.Numbers.Add(info);
            _dataContext.SaveChanges();
        }
        public void Update(NumberInfo info) 
        {
            _dataContext.Update(info);
            _dataContext.SaveChanges();
        }  
        public void Remove(NumberInfo info)
        {
            _dataContext.Remove(info);
            _dataContext.SaveChanges();
        }
    }
}
