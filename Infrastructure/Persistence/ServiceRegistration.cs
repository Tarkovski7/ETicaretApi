using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concretes;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection service)
        {
            service.AddSingleton<IProductService , ProductService>();
        }
    }
}