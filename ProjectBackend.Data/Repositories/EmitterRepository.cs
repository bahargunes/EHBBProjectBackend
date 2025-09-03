using ProjectBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.Contracts.RepositoryInterfaces;

namespace ProjectBackend.Data.Repositories
{
    public class EmitterRepository : IEmitterRepository<Emitter>
    {
        private readonly ApplicationDbContext _context;

        public EmitterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Emitter>> GetAllAsync()
        {
            var emitters = await _context.Emitters
                                    .Include(l => l.Modes)
                                    .ToListAsync();
            return emitters;
        }

        public async Task<Emitter?> GetByIdAsync(int id)
        {
            var emitter = await _context.Emitters
                    .Include(l => l.Modes)
                    .FirstOrDefaultAsync(l => l.EmitterId == id);
            return emitter;
        }

        public async Task<Emitter> AddAsync(Emitter entity)
        {
            _context.Emitters.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emitter = await _context.Emitters.FindAsync(id);
            if (emitter == null)
            {
                return false;
            }
            _context.Emitters.Remove(emitter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Emitter> UpdateAsync(Emitter entity)
        {
            _context.Emitters.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Emitter?> GetByNameAsync(string name)
        {
            return await _context.Emitters
                                 .FirstOrDefaultAsync(e => e.EmitterName == name);
        }

        public async Task<Emitter?> GetBySpotNoAsync(string SpotNo)
        {
            return await _context.Emitters
                                 .FirstOrDefaultAsync(e => e.SpotNo == SpotNo);
        }
    }
}
