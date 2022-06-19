using System;
using System.Collections.Generic;
using RestAPI.Entities;


namespace RestAPI.Repositories

{
     public interface IItemsRepository
    {
        Item GetItem(int id);

        IEnumerable<Item> GetItems();
    }
}