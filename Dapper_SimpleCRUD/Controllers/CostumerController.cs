using Dapper_SimpleCRUD.Models;
using Dapper_SimpleCRUD.Repository;
using Dapper_SimpleCRUD.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_SimpleCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CostumerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await customerRepository.GetAllAsync());
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await customerRepository.GetByIdAsync(id);
            if (data ==null) return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
           
            return Ok(await customerRepository.AddAsync(customer));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await customerRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            return Ok(await customerRepository.UpdateAsync(customer));
        }
    }
}
