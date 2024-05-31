using System.Collections.Generic;
using System.Reflection.Emit;

namespace Test_Task.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<DofusContext> options) : base(options) { }
        public DbSet<News> NewsItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the 'News' entity to map to the 'News' table
            modelBuilder.Entity<News>().ToTable("News");
        }
    }
}
