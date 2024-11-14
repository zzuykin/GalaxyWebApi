
using AutoMapper;
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Managers
{
    public class FeedbackManager : IFeedbackManager
    {
        private readonly DataContext _dataContext;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackManager(DataContext dataContext, IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _dataContext = dataContext;
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public Guid Create(EditFeedback editFeedback)
        {
            var feedback = _mapper.Map<Feedback>(editFeedback);
            //var isnNode = _feedbackRepository.Create(context,feedback);
            //return isnNode.IsnNode;
            return _feedbackRepository.Create(_dataContext, feedback).IsnNode;
        }
    }
}
