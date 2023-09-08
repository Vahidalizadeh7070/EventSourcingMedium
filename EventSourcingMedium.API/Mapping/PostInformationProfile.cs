using AutoMapper;
using EventSourcingMedium.API.CQRS.Command.Create;
using EventSourcingMedium.API.CQRS.Query.GetAll;
using EventSourcingMedium.API.DTO;
using EventSourcingMedium.API.Models;

namespace EventSourcingMedium.API.Mapping
{
    public class PostInformationProfile : Profile
    {
        public PostInformationProfile()
        {
            CreateMap<CreatePostInformationDTO, CreatePostInformationRecord>();
            CreateMap<CreatePostInformationRecord, PostInformation>();
            CreateMap<PostInformation, PostInformationResponseDTO>();
            
        }
    }
}
