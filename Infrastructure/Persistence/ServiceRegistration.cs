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
            service.AddDbContext<EticaretApiDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);

            service.AddSingleton<IProductReadRepository , ProductReadRepository>();
            service.AddSingleton<IProductWriteRepository , ProductWriteRepository>();
            
            service.AddSingleton<IOrderReadRepository , OrderReadRepository>();
            service.AddSingleton<IOrderWriteRepository , OrderWriteRepository>();
            
            service.AddSingleton<ICustomerReadRepository , CustomerReadRepository>();
            service.AddSingleton<ICustomerWriteRepository , CustomerWriteRepository>();
        }
    }
}