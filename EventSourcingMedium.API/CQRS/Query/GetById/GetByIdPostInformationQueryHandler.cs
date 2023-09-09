using AutoMapper;
using Events;
using EventSourcingMedium.API.DTO;
using EventSourcingMedium.API.Services.EventStreaming;
using EventSourcingMedium.API.Services.PostInformationServices.QueryService;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Query.GetById
{
    public class GetByIdPostInformationQueryHandler : IRequestHandler<GetByIdPostInformationRecord, PostInformationResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostInformationQueryService _postInformationQueryService;
        private readonly IEventStoreService _eventStoreService;

        public GetByIdPostInformationQueryHandler(IMapper mapper, IPostInformationQueryService postInformationQueryService, IEventStoreService eventStoreService)
        {
            _mapper = mapper;
            _postInformationQueryService = postInformationQueryService;
            _eventStoreService = eventStoreService;
        }
        public async Task<PostInformationResponseDTO> Handle(GetByIdPostInformationRecord request, CancellationToken cancellationToken)
        {
            var res = _postInformationQueryService.GetById(request.Id);
            if (res is not null)
            {
                object getByIdPostEvent = new GetByIdPostEvent
                {
                    Id = res.Id,
                    CreateDate = res.CreatedDate,
                    Title = res.Title
                };
                await _eventStoreService.AppendEventAsync(getByIdPostEvent);
                return _mapper.Map<PostInformationResponseDTO>(res);
            }
            return null;
        }
    }
}
