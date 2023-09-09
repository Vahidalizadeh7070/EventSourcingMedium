using AutoMapper;
using Events;
using EventSourcingMedium.API.DTO;
using EventSourcingMedium.API.Models;
using EventSourcingMedium.API.Services.EventStreaming;
using EventSourcingMedium.API.Services.PostInformationServices.CommandService;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Command.Create
{
    // As shown in the above code, this class hanlde by CreatePostInformationRecord object and show PostInformationResponseDTO as a result
    public class CreatePostInformationCommandHandler : IRequestHandler<CreatePostInformationRecord, PostInformationResponseDTO>
    {
        private readonly IPostInformationCommandService _postInformationCommandService;
        private readonly IEventStoreService _eventStoreService;
        private readonly IMapper _mapper;

        public CreatePostInformationCommandHandler(IMapper mapper, IPostInformationCommandService postInformationCommandService, IEventStoreService eventStoreService)
        {
            _postInformationCommandService = postInformationCommandService;
            _eventStoreService = eventStoreService;
            _mapper = mapper;
        }
        public async Task<PostInformationResponseDTO> Handle(CreatePostInformationRecord request, CancellationToken cancellationToken)
        {
            var mapModel = _mapper.Map<PostInformation>(request);

            var res = await _postInformationCommandService.AddAsync(mapModel);

            // That is the wrong way
            // Event should be added
            // await _eventStoreService.AppendEventAsync(res);

            object CreatedEvent = new CreatePostEvent
            {
                Id = res.Id,
                Title = res.Title,
                UserName = res.UserName,
                CreatedDate = res.CreatedDate   
            };

            await _eventStoreService.AppendEventAsync(CreatedEvent);
            var mapResult = _mapper.Map<PostInformationResponseDTO>(res);

            return mapResult;


        }
    }
}
