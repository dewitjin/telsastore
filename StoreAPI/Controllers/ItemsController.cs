using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models.Dtos;
using StoreAPI.Repository.IRepository;
using System.Collections.Generic;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemRepository _iRepo;
        private readonly IMapper _mapper;

        public ItemsController(IItemRepository oRepo, IMapper mapper)
        {
            _iRepo = oRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetItems() {
            var objList = _iRepo.GetItems();
            var objDto = new List<GetItemDto>();

            foreach (var obj in objList) {
                objDto.Add(_mapper.Map<GetItemDto>(obj));
            }

            return Ok(objDto);
        }
    }
}
