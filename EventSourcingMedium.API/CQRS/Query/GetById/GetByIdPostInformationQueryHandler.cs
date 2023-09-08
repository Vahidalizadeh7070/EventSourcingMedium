using AutoMapper;
using EventSourcingMedium.API.DTO;
using EventSourcingMedium.API.Services.PostInformationServices.QueryService;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Query.GetById
{
    public class GetByIdPostInformationQueryHandler : IRequestHandler<GetByIdPostInformationRecord, PostInformationResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostInformationQueryService _postInformationQueryService;

        public GetByIdPostInformationQueryHandler(IMapper mapper, IPostInformationQueryService postInformationQueryService)
        {
            _mapper = mapper;
            _postInformationQueryService = postInformationQueryService;
        }
        public async Task<PostInformationResponseDTO> Handle(GetByIdPostInformationRecord request, CancellationToken cancellationToken)
        {
            var res = _postInformationQueryService.GetById(request.Id);
            if (res is not null)
            {
                return _mapper.Map<PostInformationResponseDTO>(res);
            }
            return null;
        }
    }
}
