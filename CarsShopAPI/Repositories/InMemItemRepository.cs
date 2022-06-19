using System;
using System.Linq;
using System.Collections.Generic;
using RestAPI.Entities;
using RestAPI.Controllers;

namespace RestAPI.Repositories
{
    
   

    public class InMemItemRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = 1, CarMake = "Toyota", CarModel = "Supra", Price = 322, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = 2, CarMake = "Seat", CarModel = "Leon", Price = 322, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = 3, CarMake = "Audi", CarModel = "A4", Price = 422, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = 4, CarMake = "Honda", CarModel = "Accord", Price = 322, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems() {
            return items;
        }

        public Item GetItem(int id) {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(int id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }


}