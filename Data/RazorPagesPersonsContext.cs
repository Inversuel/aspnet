using Microsoft.EntityFrameworkCore;
using RazorPagesAspnet.Models;

namespace RazorPagesAspnet.Data
{
    public class RazorPagesAspnetContext : DbContext
    {
        public RazorPagesAspnetContext (DbContextOptions<RazorPagesAspnetContext> options)
            : base(options)
        {
        }

        public DbSet<Persons> Persons { get; set; } = default!;
        public DbSet<Emails> Emails { get; set; } = default!;
    }
}
