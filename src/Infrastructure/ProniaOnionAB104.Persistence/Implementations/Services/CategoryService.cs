using Microsoft.EntityFrameworkCore;
using ProniaApi.Application.DTOs.Category;
using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Application.Abstractions.Services;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CategoryCreateDto createCategoryDto)
        {
            Category category = new Category
            {
                Name = createCategoryDto.Name
            };
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, IsTracking: false).ToListAsync();

            ICollection<CategoryItemDto> getCategoryDtos = new List<CategoryItemDto>();

            foreach (Category category in categories)
            {
                getCategoryDtos.Add(new CategoryItemDto(category.Id, category.Name));
            }
            return getCategoryDtos;
        }


        public async Task UpdateAsync(int id, CategoryUpdateDto updateCategoryDto)
        {
            Category category = await _repository.GetByIdAsync(id);

            if (category is null) throw new Exception("Not found");

            category.Name = updateCategoryDto.Name;

            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);

            if (category is null) throw new Exception("Not found");

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        //public async Task<CategoryItemDto> GetAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);

        //    if (category is null) throw new Exception("Not found");

        //    return new CategoryItemDto()
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //    };
        //}

    }
}
