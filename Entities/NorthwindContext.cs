using Microsoft.EntityFrameworkCore;

public class NorthwindContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Northwind;User Id=sa;Password=Sa12345;");
    }
}

