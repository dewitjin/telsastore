using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;
using StoreAPI.Models.Dtos;
using StoreAPI.Repository.IRepository;
using System.Collections.Generic;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _cRepo;
        private IAddressRepository _aRepo;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository cRepo, IAddressRepository aRepo, IMapper mapper)
        {
            _cRepo = cRepo;
            _aRepo = aRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var objList = _cRepo.GetCustomers();
            var objDto = new List<GetCustomerDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<GetCustomerDto>(obj));
            }

            return Ok(objDto);
        }

        [HttpGet("{customerID:int}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int customerID)
        {
            var obj = _cRepo.GetCustomer(customerID);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<GetCustomerDto>(obj);

            return Ok(objDto); 
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_cRepo.CustomerExists(customerDto.Name))
            {
                ModelState.AddModelError("", "Customer Exists!");
                return StatusCode(404, ModelState);
            }

            if (customerDto.address == null)
            {
                return BadRequest(ModelState);
            }

            //If the address was already created, find address id to create customer record
            var address = _aRepo.GetAddressByStreet(customerDto.address.Street);

            if (address == null)
            {
                if (!_aRepo.CreateAddress(customerDto.address))
                {
                    ModelState.AddModelError("", $"Something went wrong when saving the record {customerDto.address.Street}");
                    return StatusCode(500, ModelState);
                }

                address = _aRepo.GetAddressByStreet(customerDto.address.Street);
            }
            
            var customerObj = new Customer() { Name = customerDto.Name, AddressId = address.Id };

            if (!_cRepo.CreateCustomer(customerObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {customerDto.Name}");
                return StatusCode(500, ModelState);
            }

            //Can't use mapper here because the properties have to be the same in both models.
            //Return the Dto to not show just the address id not the full address.
            var getCustomerDto = new GetCustomerDto() { Id = customerObj.Id, Name = customerObj.Name, AddressID = address.Id };

            return CreatedAtRoute("GetCustomer", new { customerId = customerObj.Id }, getCustomerDto);
        }
    }
}
