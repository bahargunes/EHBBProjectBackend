using Microsoft.EntityFrameworkCore;
using ProjectBackend.Data.Entities;
using ProjectBackend.Contracts.RepositoryInterfaces;
namespace ProjectBackend.Data.Repositories
{
    public class PlatformRepository : IPlatformRepository<Platform>
    {
        private readonly ApplicationDbContext _context;

        public PlatformRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Platform>> GetAllAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform?> GetByIdAsync(int id)
        {
            return await _context.Platforms.FindAsync(id);
        }

        public async Task<Platform> AddAsync(Platform entity)
        {
            _context.Platforms.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return false;
            }
            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Platform> UpdateAsync(Platform entity)
        {
            _context.Platforms.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
