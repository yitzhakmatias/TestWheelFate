using BL.CORE;
using DAL.ContextData;

namespace BL.Services.Repositories
{
    class EngineerRepository : EntityRepository<Engineer, WheelContext>, IEngineerRepository
    {
        public EngineerRepository(IDataContextFactory<WheelContext> databaseFactory) : base(databaseFactory)
        {
        }
    }
}