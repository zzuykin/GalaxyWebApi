using AutoMapper;
using Galaxy.Storage.Models;
using WebApplication1.Features.ViewModels;
namespace WebApplication1.Features.Mappers
{
    public class FeedbackMapper : Profile 
    {
        public FeedbackMapper()
        {
            CreateMap<EditFeedback, Feedback>();
            CreateMap<Feedback, EditFeedback>();
        }
    }
}
