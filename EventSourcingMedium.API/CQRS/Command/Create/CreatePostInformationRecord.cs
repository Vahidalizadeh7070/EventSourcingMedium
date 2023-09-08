using EventSourcingMedium.API.DTO;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Command.Create
{
    // IRequest should express the result object
    // Here, a response dto will be used 
    public record CreatePostInformationRecord
    (
        string Id,
        string Title,
        string UserName, 
        DateTime CreateDate
    ) : IRequest<PostInformationResponseDTO>;
}
