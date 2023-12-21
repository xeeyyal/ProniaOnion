﻿using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Domain.Entities;
using ProniaOnionAB104.Persistence.Contexts;
using ProniaOnionAB104.Persistence.Implementations.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Persistence.Implementations.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

    }
}
