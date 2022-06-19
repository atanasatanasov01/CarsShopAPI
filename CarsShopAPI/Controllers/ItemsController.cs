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

        // POST req => /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = itemDto.Id,
                CarMake = itemDto.CarMake,
                CarModel = itemDto.CarModel,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.AsDto());
        
        }


        // PUT req /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, UpdateItemDto itemDto) {

            var existingItem = repository.GetItem(id);

            if (existingItem is null) {
                return NotFound();
            }

            Item updatedItem = existingItem with {
                CarMake = itemDto.CarMake,
                CarModel = itemDto.CarModel,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        // Delete => /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id){
            var existingItem = repository.GetItem(id);

            if(existingItem is null) {
                return NotFound();
            }

            repository.DeleteItem(id);
            
            return NoContent();
        }
    }
}