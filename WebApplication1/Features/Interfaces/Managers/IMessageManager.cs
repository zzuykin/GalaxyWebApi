

using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Interfaces.Managers
{
    public interface IMessageManager
    {
        public Guid Create(EditMessage editMessage);
    }
}
