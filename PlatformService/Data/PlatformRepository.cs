using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext context;

        public PlatformRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public Platform GetById(int id)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public void Creat(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException(nameof(platform));
            
            context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAll()
        {
            return context.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}