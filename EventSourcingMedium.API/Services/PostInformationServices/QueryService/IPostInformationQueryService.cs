using EventSourcingMedium.API.Models;

namespace EventSourcingMedium.API.Services.PostInformationServices.QueryService
{
    public interface IPostInformationQueryService
    {
        IEnumerable<PostInformation> GetAllPosts();
        PostInformation GetById(string id);
    }
}
