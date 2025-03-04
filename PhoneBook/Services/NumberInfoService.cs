using DL.DataContext;
using Microsoft.EntityFrameworkCore;
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
        public event Action<NumberInfo> OnNumberInfoAdded = null!;
        public event Action<NumberInfo> OnNumberInfoChanged = null!;
        public event Action<NumberInfo> OnNumberInfoDeleted = null!;
        public List<NumberInfo> GetNumbers()
        {
            return _dataContext.Numbers.AsNoTracking().Map().ToList();
        }
        public void Add(NumberInfo info)
        {
            var mapObj = info.Map();
            _dataContext.Numbers.Add(mapObj);
            _dataContext.SaveChanges();
            OnNumberInfoAdded?.Invoke(info);
        }
        public void Update(NumberInfo info) 
        {
            info.LastUpdateDate = DateTimeOffset.Now;
            DetachObject(info);
            _dataContext.Numbers.Update(info.Map());
            _dataContext.SaveChanges();
            OnNumberInfoChanged?.Invoke(info);
        }  
        public void Remove(NumberInfo info)
        {
            DetachObject(info);
            _dataContext.Remove(info.Map());
            _dataContext.SaveChanges();
            OnNumberInfoDeleted?.Invoke(info);
        }
        private void DetachObject(NumberInfo info)
        {
            var existingObject = _dataContext.Numbers.FirstOrDefault(x => x.Number == info.Number);
            if (existingObject != null)
            {
                _dataContext.Entry(existingObject).State = EntityState.Detached;
            }
        }
    }
}
