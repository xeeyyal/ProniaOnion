using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Application.Abstractions.Services;
using ProniaOnionAB104.Application.DTOs.Product;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Persistence.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository categoryRepository, IColorRepository colorRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _colorRepository = colorRepository;
        }
        public async Task<IEnumerable<ProductItemDto>> GetAllPaginatedAsync(int page, int take)
        {
            IEnumerable<ProductItemDto> dtos = _mapper.Map<IEnumerable<ProductItemDto>>(
                await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false).ToArrayAsync()
                );
            return dtos;
        }
        public async Task<ProductGetDto> GetByIsAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id, includes: nameof(Product.Category));
            ProductGetDto dto = _mapper.Map<ProductGetDto>(product);
            return dto;
        }
        public async Task CreateAsync(ProductCreateDto productCreateDto)
        {
            if (await _repository.IsExistAsync(p => p.Name == productCreateDto.Name)) throw new Exception("Bu adda product artiq movcuddur");

            if (!await _categoryRepository.IsExistAsync(c => c.Id == productCreateDto.CategoryId)) throw new Exception("Bu id-li category movcuddur");

            Product product = _mapper.Map<Product>(productCreateDto);

            product.ProductColors = new List<ProductColor>();
            foreach (var colorId in productCreateDto.ColorIds)
            {
                if (!await _colorRepository.IsExistAsync(c => c.Id == colorId)) throw new Exception("Bu id-li color movcuddur");

                product.ProductColors.Add(new ProductColor { ColorId = colorId });
            }
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, ProductUpdateDto productUpdateDto)
        {
            Product existed = await _repository.GetByIdAsync(id, includes: nameof(Product.ProductColors));
            if (existed is null) throw new Exception("Not found");
            if (productUpdateDto.CategorId != existed.CategoryId)
            {
                if (!await _categoryRepository.IsExistAsync(c => c.Id == productUpdateDto.CategorId)) throw new Exception("Bu id li category movcuddur");
            }
            existed = _mapper.Map(productUpdateDto, existed);
            existed.ProductColors = existed.ProductColors.Where(pc => productUpdateDto.ColorIds.Any(colorId => pc.ColorId == colorId)).ToList();

            foreach (var cId in productUpdateDto.ColorIds)
            {
                if (!await _colorRepository.IsExistAsync(c => c.Id == cId)) throw new Exception("Bu id li color movcuddur");
                if (!existed.ProductColors.Any(pc => pc.ColorId == cId))
                {
                    existed.ProductColors.Add(new ProductColor { ColorId = cId });
                }
            }
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);
            if (product is null) throw new Exception("Not found");
            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);
            if (product is null) throw new Exception("Not found");
            _repository.SoftDelete(product);
            await _repository.SaveChangesAsync();
        }
    }
}
