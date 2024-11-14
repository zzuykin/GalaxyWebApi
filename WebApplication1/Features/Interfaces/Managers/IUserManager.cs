using Galaxy.Storage.Models;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Interfaces.Managers
{
    public interface IUserManager
    {
        public Guid Create(EditUser editUser);
        public User GetUserByEmail(string email);

        public string HashPassword(string password);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}
