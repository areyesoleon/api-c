using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MasterAPI.Models
{
    public class MasterModel
    {
        [BsonId]
        public ObjectId Id {get; set;}
    }
}