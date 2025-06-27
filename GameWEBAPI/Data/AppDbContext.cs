using Game.Models;
using Microsoft.EntityFrameworkCore;


namespace Game.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Asmond", Class= "Mage", Dmg = 12, Hp = 100 },
                new Character { Id = 2, Name = "Loki", Class = "Warrior", Dmg = 3, Hp = 100},
                new Character { Id = 3, Name = "Trevor", Class = "Assasin", Dmg = 8, Hp = 100 }
            );
        }
    }
}
