using System;
using System.Collections.Generic;
using RestAPI.Entities;


namespace RestAPI.Repositories

{
     public interface IItemsRepository
    {
        Item GetItem(int id);

        IEnumerable<Item> GetItems();
        void CreateItem(Item item);

        void UpdateItem(Item item);

        void DeleteItem(int id);
    }
}