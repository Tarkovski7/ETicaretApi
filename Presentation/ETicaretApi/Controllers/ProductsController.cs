using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.ViewModels.Products;
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
        public async Task<IActionResult> Get()
        {
            return Ok(readRepository.GetAll(false));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await readRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Created_Product model)
        {
            await writeRepository.AddAsync(new(){
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Updated_Product model)
        {
            Product product = await readRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string id)
        {
            await writeRepository.RemoveAsync(id);
            await writeRepository.SaveAsync();

            return Ok();
        }

    }
}