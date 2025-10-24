using IMDB.DataServiceLayer.Models;
namespace IMDB.DataServiceLayer;

public interface IUserService
{
    // Users
    int RegisterUser(string username, string password, string email);
    IList<AppUser> GetUsers();
    AppUser? UserLogin(string email, string password);
    AppUser? GetUserById(int id);
    bool DeleteUserById(int id);
    
    //movies
}

