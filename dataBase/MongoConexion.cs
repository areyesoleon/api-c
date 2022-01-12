using MongoDB.Driver;

namespace MasterAPI.dataBase
{
    public class MongoConexion
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoConexion()
        {
            client = new MongoClient("mongodb+srv://admin:admin@cluster0.khnqa.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            db = client.GetDatabase("Inventory");
        }
    }
}