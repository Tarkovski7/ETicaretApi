using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concretes.Repositories;
using Persistence.Contexts;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection service)
        {
            service.AddDbContext<EticaretApiDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            service.AddScoped<IProductReadRepository , ProductReadRepository>();
            service.AddScoped<IProductWriteRepository , ProductWriteRepository>();
            
            service.AddScoped<IOrderReadRepository , OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository , OrderWriteRepository>();
            
            service.AddScoped<ICustomerReadRepository , CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository , CustomerWriteRepository>();
        }
    }
}