using System;
using System.Collections.Generic;
using RestAPI.Entities;
using RestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RestAPI.Dtos;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase 
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository) {
            this.repository = repository;
        }

        // GET request -> /items;
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;   
        }

        // GET request /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(int id)
        {
            var item = repository.GetItem(id);

            if(item is null) {
                return NotFound();
            }
            return item.AsDto();
        }
    }
}