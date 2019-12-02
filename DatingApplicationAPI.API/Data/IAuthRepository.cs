using System.Threading.Tasks;
using DatingApplicationAPI.API.Models;

namespace DatingApplicationAPI.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user,string password);
         Task<User> Login(string username,string password);
         Task<bool> UserExists(string username);
    }
}