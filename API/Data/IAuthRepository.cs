using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(string userName, string password);
         Task<User> Login(string userName, string password);
         Task<bool> UserExists(string userName);
    }
}