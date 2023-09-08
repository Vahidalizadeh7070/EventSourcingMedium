using EventSourcingMedium.API.Models;

namespace EventSourcingMedium.API.Services.PostInformationServices.CommandService
{
    public class PostInformationCommandService : IPostInformationCommandService
    {
        private readonly AppDbContext _dbContext;

        public PostInformationCommandService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PostInformation> AddAsync(PostInformation postInformation)
        {
            if (postInformation is not null)
            {
                await _dbContext.PostInformation.AddAsync(postInformation);
                await _dbContext.SaveChangesAsync();
            }
            return postInformation;
        }
    }
}
