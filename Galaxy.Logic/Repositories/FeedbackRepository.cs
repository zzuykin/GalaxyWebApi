using Galaxy.Logic.Interfaces;
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;

namespace Galaxy.Logic.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Feedback Create(DataContext context, Feedback feedback)
        {
            feedback.IsnNode = Guid.NewGuid();
            context.Feedbacks.Add(feedback);
            context.SaveChanges();
            return feedback;
        }

        public Feedback Update (DataContext context, Feedback feedback)
        {
            var feedbackDb = context.Feedbacks.FirstOrDefault(x => x.IsnNode == feedback.IsnNode)
                ?? throw new Exception($"Не найдет такой отзыв с индификатором {feedback.IsnNode}");

            feedbackDb.ClientEmail = feedback.ClientEmail;
            feedbackDb.ClientName = feedback.ClientName;
            feedbackDb.feedBackText = feedback.feedBackText;
            feedbackDb.forPublic = feedback.forPublic;

            return feedbackDb;
        }

        public void Delete(DataContext context, Guid isnNode)
        {
            var feedbackDb = context.Feedbacks.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Не найдет такой отзыв с индификатором {isnNode}");
            context.Feedbacks.Remove(feedbackDb);
            context.SaveChanges();
        }

        public Feedback GetById(DataContext context,Guid isnNode)
        {
            var feedbackDb = context.Feedbacks.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Не найдет такой отзыв с индификатором {isnNode}");

            return feedbackDb;
        }
    }
}
