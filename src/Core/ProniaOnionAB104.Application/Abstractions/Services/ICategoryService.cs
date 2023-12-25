﻿using ProniaOnionAB104.Application.DTOs.Category;
using ProniaOnionAB104.Application.DTOs.Categories;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<CategoryGetDto> GetAsync(int id);
        Task CreateAsync(CategoryCreateDto categoryDto);
        Task UpdateAsync(int id, CategoryUpdateDto categoryDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
