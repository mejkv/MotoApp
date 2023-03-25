using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {
        //void AddBatch(T[] item);
    }
}
