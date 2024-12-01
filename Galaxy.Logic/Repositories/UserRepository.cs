

using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(DataContext context, User user)
        {
            user.IsnNode = Guid.NewGuid();
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Update(DataContext context, User user)
        {
            var userBd = context.Users.FirstOrDefault(x => x.IsnNode == user.IsnNode)
                ?? throw new Exception($"Пользователя с Id {user.IsnNode} не найден");
            userBd = user;
            return userBd;
        }

        public void Delete(DataContext context, Guid isnNode)
        {
            var userBd = context.Users.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Пользователя с Id {isnNode} не найден");
            context.Remove(userBd);
            context.SaveChanges();
        }

        public User GetById(DataContext context, Guid id)
        {
            var userBd = context.Users.FirstOrDefault(x => x.IsnNode == id)
                ?? throw new Exception($"Пользователя с Id {id} не найден");
            return userBd;
        }

        public User GetByEmail(DataContext context, string email)
        {
            var userBd = context.Users.FirstOrDefault(x => x.ClientEmail == email);
            return userBd;
        }

        public bool isEmailReg(DataContext context, string email)
        {
            return context.Users.FirstOrDefault(x => x.ClientEmail == email) != null;
        }
    }
}
