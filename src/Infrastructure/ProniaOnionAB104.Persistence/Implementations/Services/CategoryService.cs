using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaApi.Application.DTOs.Category;
using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Application.Abstractions.Services;
using ProniaOnionAB104.Application.DTOs.Categories;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDto createCategoryDto)
        {
            await _repository.AddAsync(_mapper.Map<Category>(createCategoryDto));

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false,isDeleted:true).ToListAsync();

            ICollection<CategoryItemDto> categoryItemDtos = _mapper.Map<ICollection<CategoryItemDto>>(categories);
            
            return categoryItemDtos;
        }


        public async Task UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            Category category = await _repository.GetByIdAsync(id);

            if (category is null) throw new Exception("Not found");

            category.Name = categoryUpdateDto.Name;

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
        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not found");
            _repository.SoftDelete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<CategoryGetDto> GetAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not found");
            return new CategoryGetDto(category.Id, category.Name);
        }
    }
}
