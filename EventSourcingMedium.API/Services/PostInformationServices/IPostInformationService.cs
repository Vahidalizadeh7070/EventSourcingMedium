using EventSourcingMedium.API.Models;

namespace EventSourcingMedium.API.Services.PostInformationServices
{
    public interface IPostInformationService
    {
        Task<PostInformation> AddAsync(PostInformation postInformation);
        IEnumerable<PostInformation> GetAllPosts();
        PostInformation GetById(string id);

    }
}
