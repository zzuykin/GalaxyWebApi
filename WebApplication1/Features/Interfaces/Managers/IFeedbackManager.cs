
using Galaxy.Storage.DataBase;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Interfaces.Managers
{
    public interface IFeedbackManager
    {
        public Guid Create(EditFeedback editFeedback);
    }
}
