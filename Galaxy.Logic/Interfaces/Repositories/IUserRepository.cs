using Galaxy.Storage.Models;
using Galaxy.Storage.DataBase;
namespace Galaxy.Logic.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User Create(DataContext context, User user);
        public User Update(DataContext context, User user);

        public void Delete(DataContext context, Guid isNode);

        public User GetById(DataContext context, Guid id);

        public User GetByEmail(DataContext context, string email);

    }
}
