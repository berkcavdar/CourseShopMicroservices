using MongoDB.Bson.Serialization.Attributes;

namespace Course.Sevices.Catalog.API.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }    
    }
}
