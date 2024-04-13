using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(EticaretApiDbContext context) : base(context)
        {
        }
    }
}