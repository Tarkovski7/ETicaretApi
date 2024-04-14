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
        private readonly IOrderWriteRepository orderWriteRepository;
        private readonly ICustomerWriteRepository customerWriteRepository;
        private readonly IOrderReadRepository orderReadRepository;

        public ProductsController(IProductReadRepository readRepository, IProductWriteRepository writeRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.orderWriteRepository = orderWriteRepository;
            this.customerWriteRepository = customerWriteRepository;
            this.orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            Order order = await orderReadRepository.GetByIdAsync("56d3bf19-10e7-4144-9af2-08dc5c8c7f7b");
            order.Address = "asdlaskdmasdlaskmd kasmdlaskmdasl";
            await orderWriteRepository.SaveAsync();
        }
    }
}