using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PixyDeltaApi.Models;

#region Only when using Identity User
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("pd");
        base.OnModelCreating(builder);
    }
    public DbSet<Notes>? Notes { get; set; }
}
#endregion

// public class ApplicationDbContext : DbContext
// {
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//         builder.HasDefaultSchema("pd");
//         base.OnModelCreating(builder);
//     }
//     public DbSet<Notes>? notes { get; set; }
// }