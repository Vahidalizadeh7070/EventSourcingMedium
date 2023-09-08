using EventSourcingMedium.API.DTO;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Query.GetAll
{
    public record GetAllPostInformationRecord 
    (
    ): IRequest<IEnumerable<PostInformationResponseDTO>>;
}
