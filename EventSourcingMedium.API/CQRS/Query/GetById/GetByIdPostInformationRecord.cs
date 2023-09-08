using EventSourcingMedium.API.DTO;
using MediatR;

namespace EventSourcingMedium.API.CQRS.Query.GetById
{
    public record GetByIdPostInformationRecord 
    (
        string Id
    ) : IRequest<PostInformationResponseDTO>;
}
