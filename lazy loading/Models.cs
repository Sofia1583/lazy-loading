using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()        // подключение lazy loading
            .UseSqlite("Data Source=helloapp.db");
    }
}
public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual List<User> Users { get; set; } = new();
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}
