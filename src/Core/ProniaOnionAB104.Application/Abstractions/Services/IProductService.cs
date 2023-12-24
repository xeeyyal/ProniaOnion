using Microsoft.AspNetCore.Mvc;
using ProniaApi.Application.DTOs.Category;
using ProniaApi.Application.DTOs.Product;
using ProniaOnionAB104.Application.DTOs.Categories;
using ProniaOnionAB104.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllPaginatedAsync(int page, int take);
        Task<ProductGetDto> GetByIsAsync(int id);
        Task CreateAsync(ProductCreateDto productCreateDto);
    }
}
