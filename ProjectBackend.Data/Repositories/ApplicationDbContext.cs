using ProjectBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectBackend.Data.Repositories

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Laser> Lasers { get; set; }
        public DbSet<Emitter> Emitters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LaserMode>()
           .Property(lm => lm.LaserModeId).ValueGeneratedOnAdd();

            modelBuilder.Entity<EmitterMode>()
           .Property(lm => lm.EmitterModeId).ValueGeneratedOnAdd();


        }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps() // to automatically set DateCreated and DateLastUpdated
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Platform &&
                           (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                var entity = (Platform)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.DateCreated = DateTime.UtcNow;
                }

                entity.DateLastUpdated = DateTime.UtcNow;
            }
        }
    }
}
