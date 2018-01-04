using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using BL.CORE;

namespace DAL.DataContext
{
    public class WheelContext : DbContext, IDbContext
    {
        public WheelContext() : base("name=WheelContext")
        {
        }

        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        public DbSet<TaskEngineer> Tasks { get; set; }

        //public DbSet<Author> Authors { get; set; }

        public ObjectResult<TEntity> SpObjectResult<TEntity>() where TEntity : class
        {
            return null;
        }
    }
}
