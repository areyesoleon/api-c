using MasterAPI.dataBase;
using MasterAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MasterAPI.tools
{
    public class ApiCollection<T> : ApiInterface<T> where T : MasterModel
    {

        internal MongoConexion _repository = new MongoConexion();
        private IMongoCollection<T> Collection;
        public ApiCollection(string collection)
        {
            Collection = _repository.db.GetCollection<T>(collection);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<T>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task Post(T data)
        {
            await Collection.InsertOneAsync(data);
        }

        public async Task Put(T data)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, data.Id);
            await Collection.ReplaceOneAsync(filter, data);
        }
    }
}