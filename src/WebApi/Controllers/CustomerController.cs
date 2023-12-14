using System;
using System.Text.Json;
using WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL.Abstractions;
using System.Text.Json.Serialization;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _userRepository;

        public CustomerController(IRepository<Customer> userRepository)
        {
            _userRepository = userRepository;
        }
    
        [HttpGet("{id:long}")]   
        public IActionResult GetCustomer([FromRoute] long id)
        {
            var result = _userRepository.Get(id);
            JsonSerializer.Serialize(result);
            if (result != null)
            {
                return Ok(
                    JsonSerializer.Serialize(result));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]   
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = _userRepository.Add(customer);
            
            if (result != null)
            {
                return Ok(
                    JsonSerializer.Serialize(result));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}