using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
        
    }
}