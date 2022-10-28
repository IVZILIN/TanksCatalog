using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanksCatalog.Entities;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace TanksCatalog.Repositories
{

    public class MongoDbTanksRepository : ITanksRepository
    {
        private const string databaseName = "tankscatalog";
        private const string collectionName = "tanks";
        private readonly IMongoCollection<Tank> tanksCollection;
        private readonly FilterDefinitionBuilder<Tank> filterBuilder = Builders<Tank>.Filter;
        public MongoDbTanksRepository(IMongoClient mongoClient)
        {
            //изменения лев тут
            
            //end
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            tanksCollection = database.GetCollection<Tank>(collectionName);
        }
        public async Task CreateTankAsync(Tank tank)
        {
            await tanksCollection.InsertOneAsync(tank);
        }

        public async Task DeleteTankAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(tank => tank.Id, Id);
            await tanksCollection.DeleteOneAsync(filter);
        }

        public async Task<Tank> GetTankAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(tank => tank.Id, Id);
            return await tanksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task< IEnumerable<Tank>> GetTanksAsync()
        {
            return await tanksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateTankAsync(Tank tank)
        {
            var filter = filterBuilder.Eq(existingTank => existingTank.Id, tank.Id);
            await tanksCollection.ReplaceOneAsync(filter,tank);

        }
    }
}