using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository readRepository;
        private readonly IProductWriteRepository writeRepository;


        public ProductsController(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
        }
        [HttpGet]
        public async void Get()
        {
            writeRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid() , CreatedDate = DateTime.Now , Name="Product 1" , Price = 100 , Stock = 10},
                new(){Id=Guid.NewGuid() , CreatedDate = DateTime.Now , Name="Product 3" , Price = 200 , Stock = 20},
                new(){Id=Guid.NewGuid() , CreatedDate = DateTime.Now , Name="Product 2" , Price = 300 , Stock = 30},
            });
            writeRepository.SaveAsync();
        }
    }
}