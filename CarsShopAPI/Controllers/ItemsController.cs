using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                        .Select(item => item.AsDto());

            return items;   
        }

        // GET request /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(int id)
        {
            var item = await repository.GetItemAsync(id);

            if(item is null) {
                return NotFound();
            }
            return item.AsDto();
        }

        // POST req => /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = itemDto.Id,
                CarMake = itemDto.CarMake,
                CarModel = itemDto.CarModel,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {Id = item.Id}, item.AsDto());
        
        }


        // PUT req /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(int id, UpdateItemDto itemDto) {

            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null) {
                return NotFound();
            }

            Item updatedItem = existingItem with {
                CarMake = itemDto.CarMake,
                CarModel = itemDto.CarModel,
                Price = itemDto.Price
            };

            await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        // Delete => /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id){
            var existingItem = await repository.GetItemAsync(id);

            if(existingItem is null) {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            
            return NoContent();
        }
    }
}