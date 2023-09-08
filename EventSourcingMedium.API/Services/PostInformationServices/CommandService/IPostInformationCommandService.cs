using EventSourcingMedium.API.Models;

namespace EventSourcingMedium.API.Services.PostInformationServices.CommandService
{
    public interface IPostInformationCommandService
    {
        Task<PostInformation> AddAsync(PostInformation postInformation);

        // Add another commands like update or delete
    }
}
