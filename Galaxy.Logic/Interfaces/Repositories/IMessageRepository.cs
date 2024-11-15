
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        public Message Create(DataContext context, Message message);
        public Message Update(DataContext context, Message message);
        public void Delete(DataContext context, Guid isnNode);
        public Message GetById(DataContext context, Guid isnNode);
    }
}
