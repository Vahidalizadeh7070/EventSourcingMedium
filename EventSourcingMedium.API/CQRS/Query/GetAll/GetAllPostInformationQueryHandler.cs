using AutoMapper;
using EventSourcingMedium.API.DTO;
using EventSourcingMedium.API.Services.PostInformationServices.QueryService;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Query.GetAll
{
    public class GetAllPostInformationQueryHandler : IRequestHandler<GetAllPostInformationRecord, IEnumerable<PostInformationResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostInformationQueryService _postInformationQueryService;

        public GetAllPostInformationQueryHandler(IMapper mapper, IPostInformationQueryService postInformationQueryService)
        {
            _mapper = mapper;
            _postInformationQueryService = postInformationQueryService;
        }
        public async Task<IEnumerable<PostInformationResponseDTO>> Handle(GetAllPostInformationRecord request, CancellationToken cancellationToken)
        {
            var res = _postInformationQueryService.GetAllPosts();

            return _mapper.Map<IEnumerable<PostInformationResponseDTO>>(res);
        }
    }
}
