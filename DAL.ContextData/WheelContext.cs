using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using BL.CORE;

namespace DAL.DataContext
{
    public class WheelContext : DbContext, IDbContext
    {
        public WheelContext() : base("ApplicationDbContext")
        {
        }

        public DbSet<Engineer> Engineer { get; set; }

        //public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ObjectResult<TEntity> SpObjectResult<TEntity>() where TEntity : class
        {
            return null;
        }
    }
}
