using WiredBrainCoffie.StorageApp.Entities.Base;

namespace WiredBrainCoffie.StorageApp.Repository
{
    public interface IRepository<T> where T : EntityBase, IEntityBase
    {
        void Add(T item);
        T GetByID(int Id);
        void Save();
        void Remove(T item);
        IEnumerable<T> GetAll();
    }
}