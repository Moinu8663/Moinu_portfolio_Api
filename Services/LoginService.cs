using Microsoft.Extensions.Options;
using Moinu_portfolio_Api.Models;
using MongoDB.Driver;

namespace Moinu_portfolio_Api.Services;
public class LoginService
{
       private readonly IMongoCollection<LoginModels> Login;
    public LoginService(IOptions<MongoDBSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        Login = database.GetCollection<LoginModels>(settings.Value.CollectionName);
    }
        public LoginModels GetUser(LoginModels loginmodel)
    {
        return Login.Find(u => u.Login_ID == loginmodel.Login_ID && u.Password == loginmodel.Password).FirstOrDefault();
    }
}
