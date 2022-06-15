using System;
using System.Linq;
using System.Collections.Generic;
using RestAPI.Entities;

namespace RestAPI.Repositories
{
    public class InMemItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), CarMake = "Toyota", CarModel = "Supra", Price = 322, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), CarMake = "Seat", CarModel = "Leon", Price = 322, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), CarMake = "Audi", CarModel = "A4", Price = 422, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), CarMake = "Honda", CarModel = "Accord", Price = 322, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems() {
            return items;
        }

        public Item GetItem(Guid id) {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }


}