using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EticaretApiDbContext context) : base(context)
        {
        }
    }
}