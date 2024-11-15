using AutoMapper;
using Galaxy.Storage.Models;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Mappers
{
    public class MessageMapper : Profile
    {
        public MessageMapper()
        {
            CreateMap<EditMessage, Message>();
            CreateMap<Message, EditMessage>();
        }
    }
}
