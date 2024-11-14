
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Interfaces.Repositories
{
    public interface IFeedbackRepository
    {
        public Feedback Create(DataContext context, Feedback feedback);
        public Feedback Update(DataContext context, Feedback feedback);

        public void Delete(DataContext context, Guid isnNode);

        public Feedback GetById(DataContext context,Guid isnNode);
    }
}
