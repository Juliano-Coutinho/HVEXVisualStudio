using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace HVEXText.Data.Entities
{
    public class Transformer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        public string? InternalNumber { get; set; }
        public string? TensionClass { get; set; }
        public string? Potency { get; set; }
        public string? Current { get; set; }
        public IEnumerable<string>? TestsId { get; set; }
        public IEnumerable<string>? ReportsId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}