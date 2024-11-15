
using AutoMapper;
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Managers
{
    public class MessageManager : IMessageManager
    {
        private readonly DataContext _dataContext;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageManager(DataContext dataContext, IMessageRepository messageRepository, IMapper mapper)
        {
            _dataContext = dataContext;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public Guid Create(EditMessage editMessage)
        {
            var message = _mapper.Map<Message>(editMessage);
            return _messageRepository.Create(_dataContext, message).IsnNode;
        }
    }
}
