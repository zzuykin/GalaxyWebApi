using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Message Create(DataContext context, Message message)
        {
            message.IsnNode = Guid.NewGuid();
            context.Messages.Add(message);
            context.SaveChanges();
            return message;
        }

        public Message Update(DataContext context, Message message)
        {
            var MessageDb = context.Messages.FirstOrDefault(x => x.IsnNode == message.IsnNode)
                ?? throw new Exception($"Не найдет такой отзыв с индификатором {message.IsnNode}");

            MessageDb.ClientEmail = message.ClientEmail;
            MessageDb.ClientName = message.ClientName;
            MessageDb.MessageText = message.MessageText;
            MessageDb.MessageSubj = message.MessageSubj;

            return MessageDb;
        }

        public void Delete(DataContext context, Guid isnNode)
        {
            var MessageDb = context.Messages.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Не найдено такое сообщение с индификатором {isnNode}");
            context.Messages.Remove(MessageDb);
            context.SaveChanges();
        }

        public Message GetById(DataContext context, Guid isnNode)
        {
            var MessageDb = context.Messages.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Не найдено такое сообщение с индификатором {isnNode}");

            return MessageDb;
        }
    }
}
