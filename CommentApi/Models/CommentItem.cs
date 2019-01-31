using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CommentApi.Models
{
    public class CommentItem
    {
        [BsonId]                                    // Designates as document primary key
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("IsPublic")]
        public string IsPublic { get; set; }

    }
}
