using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses = Model.Models;
using UIClasses = PhoneBook.Model;

namespace PhoneBook.Mappers
{
    public static class Mapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Instance => Lazy.Value;
        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<BaseClasses.NumberInfo,UIClasses.NumberInfo>().ReverseMap();
            }
        }
    }
}
