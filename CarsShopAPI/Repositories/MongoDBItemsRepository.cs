using System;
using System.Collections.Generic;
using RestAPI.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RestAPI.Repositories
{
    public class MongoDBItemsRepository : IItemsRepository
    {
        private const string databaseName = "carsShopDB";

        private const string collectionName = "items";

        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        

       public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void DeleteItem(int id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            itemsCollection.DeleteOne(filter);
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }

        public Item GetItem(int id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

    }
}