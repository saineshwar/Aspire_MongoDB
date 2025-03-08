using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AspireApp6.ApiService.Models;

public class Product
{
    [BsonId] // Indicates this property maps to MongoDB's _id field.
    [BsonRepresentation(BsonType.ObjectId)] // Ensures it can handle ObjectId type.
    public string Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int? CategoryID { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}