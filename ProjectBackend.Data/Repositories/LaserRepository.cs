using ProjectBackend.Contracts.RepositoryInterfaces;
using ProjectBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectBackend.Data.Repositories
{
    public class LaserRepository : ILaserRepository<Laser>
    {
        private readonly ApplicationDbContext _context;

        public LaserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Laser>> GetAllAsync()
        {
            var lasers = await _context.Lasers
                                    .Include(l => l.LaserModes)
                                    .ToListAsync();
            return lasers;
        }

        public async Task<Laser?> GetByIdAsync(int id)
        {
            var laser = await _context.Lasers
                    .Include(l => l.LaserModes)
                    .FirstOrDefaultAsync(l => l.LaserId == id);
            return laser;
        }

        public async Task<Laser> AddAsync(Laser entity)
        {
            _context.Lasers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var laser = await _context.Lasers.FindAsync(id);
            if (laser == null)
            {
                return false;
            }
            _context.Lasers.Remove(laser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Laser> UpdateAsync(Laser entity)
        {
            _context.Lasers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
