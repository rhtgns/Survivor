using Microsoft.EntityFrameworkCore;
using Survivor.Entites;

public class PatikaDbContext : DbContext
{
    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=ROHATGUNES\\SQLEXPRESS0;database=PatikaCodeFirstDb2;Trusted_Connection=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competitor>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Competitors)
            .HasForeignKey(c => c.CategoryId);

        base.OnModelCreating(modelBuilder);
    }
}
