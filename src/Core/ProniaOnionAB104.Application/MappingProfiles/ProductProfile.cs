using AutoMapper;
using ProniaApi.Application.DTOs.Product;
using ProniaOnionAB104.Application.DTOs.Product;
using ProniaOnionAB104.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Application.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>().ReverseMap();
            CreateMap<Product, ProductItemDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
