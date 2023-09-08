using EventSourcingMedium.API.Models;

namespace EventSourcingMedium.API.Services.PostInformationServices
{
    public class PostInformationService : IPostInformationService
    {
        private readonly AppDbContext _dbContext;

        public PostInformationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PostInformation> AddAsync(PostInformation postInformation)
        {
            if(postInformation is not null)
            {
                await _dbContext.PostInformation.AddAsync(postInformation);
                await _dbContext.SaveChangesAsync();
            }
            return postInformation;
        }

        public IEnumerable<PostInformation> GetAllPosts()
        {
            return _dbContext.PostInformation.OrderByDescending(p=>p.CreatedDate).ToList();
        }

        public PostInformation GetById(string id)
        {
            return _dbContext.PostInformation.FirstOrDefault(p => p.Id == id);
        }
    }
}
