using System;
using System.Collections.Generic;
using RestAPI.Entities;
using RestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase 
    {
        private readonly InMemItemRepository repository;

        public ItemsController() {
            repository = new InMemItemRepository();
        }

        // GET request -> /items;
        [HttpGet]
        public IEnumerable<Item> GetItem()
        {
            var items = repository.GetItems();
            return items;
        }

        // GET request /items/{id}
        [HttpGet("{id}")]
        public Item GetItem(Guid id)
        {
            var item = repository.GetItem();
            return item;
        }
    }
}