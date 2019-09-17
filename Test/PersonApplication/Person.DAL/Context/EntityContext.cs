using Microsoft.EntityFrameworkCore;
using Person.DAL.Entity;

namespace Person.DAL.Context
{
    public class EntityContext : ConfigContext
    {
        public DbSet<PersonEntity> PersonEntities { get; set; }
        public DbSet<GenderEntity> GenderEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEntity>()
                .HasIndex(b => b.PersonNumber).IsUnique();

            modelBuilder.Entity<GenderEntity>().HasData(
                new GenderEntity() { Id = 1, Code = GenderType.MALE, Name = "Male" },
                new GenderEntity() { Id = 2, Code = GenderType.FEMALE, Name = "Female" });
        }
    }
}