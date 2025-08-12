using AutoMapper;
using FeedbackAPI.DTOs;
using FeedbackAPI.Models;

namespace FeedbackAPI.Mapper
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<CreateFeedback, Feedback>();
            CreateMap<UpdateFeedback, Feedback>();
            CreateMap<Feedback, FeedbackResponse>();
        }
    }
}
