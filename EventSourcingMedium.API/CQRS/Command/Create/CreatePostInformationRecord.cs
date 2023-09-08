using EventSourcingMedium.API.DTO;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Command.Create
{
    public record CreatePostInformationRecord
    (
        string Id,
        string Title,
        string UserName, 
        DateTime CreatedDate
    ) : IRequest<PostInformationResponseDTO>;
}
