using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Domain.Entities;
using ProniaOnionAB104.Persistence.Contexts;
using ProniaOnionAB104.Persistence.Implementations.Repositories.Common;

namespace ProniaOnionAB104.Persistence.Implementations.Repositories
{
    public class ColorRepository:Repository<Color>,IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context) { }
    }
}
