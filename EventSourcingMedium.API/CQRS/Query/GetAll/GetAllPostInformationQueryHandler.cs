using AutoMapper;
using Events;
using EventSourcingMedium.API.DTO;
using EventSourcingMedium.API.Services.EventStreaming;
using EventSourcingMedium.API.Services.PostInformationServices.QueryService;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Query.GetAll
{
    public class GetAllPostInformationQueryHandler : IRequestHandler<GetAllPostInformationRecord, IEnumerable<PostInformationResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostInformationQueryService _postInformationQueryService;
        private readonly IEventStoreService _eventStoreService;

        public GetAllPostInformationQueryHandler(IMapper mapper, IPostInformationQueryService postInformationQueryService, IEventStoreService eventStoreService)
        {
            _mapper = mapper;
            _postInformationQueryService = postInformationQueryService;
            _eventStoreService = eventStoreService;
        }
        public async Task<IEnumerable<PostInformationResponseDTO>> Handle(GetAllPostInformationRecord request, CancellationToken cancellationToken)
        {
            var res = _postInformationQueryService.GetAllPosts();
            object GetAllPostEvent = new GetAllPostEvent
            {
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid().ToString()
            };
            await _eventStoreService.AppendEventAsync(GetAllPostEvent);
            return _mapper.Map<IEnumerable<PostInformationResponseDTO>>(res);
        }
    }
}
