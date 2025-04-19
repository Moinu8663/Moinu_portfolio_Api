using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Moinu_portfolio_Api.Models;
public class LoginModels
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Login_ID { get; set; }
    public string? Password { get; set; }
}