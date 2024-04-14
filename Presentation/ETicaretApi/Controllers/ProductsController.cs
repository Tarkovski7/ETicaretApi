using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Domain.Entities;
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
        public async Task Get()
        {
            // writeRepository.AddRangeAsync(new()
            // {
            //     new(){Id=Guid.NewGuid() , CreatedDate = DateTime.Now , Name="Product 1" , Price = 100 , Stock = 10},
            //     new(){Id=Guid.NewGuid() , CreatedDate = DateTime.Now , Name="Product 3" , Price = 200 , Stock = 20},
            //     new(){Id=Guid.NewGuid() , CreatedDate = DateTime.Now , Name="Product 2" , Price = 300 , Stock = 30},
            // });
            // writeRepository.SaveAsync();

            Product p = await readRepository.GetByIdAsync("9cbe1789-218b-4bcc-af51-244c79820edf" , false);
            p.Name = "Urun 25";
            await writeRepository.SaveAsync();

        }
    }
}