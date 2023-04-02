using WiredBrainCoffie.StorageApp.Entities.Base;

namespace WiredBrainCoffie.StorageApp.Repository
{

    // interface inheritance
    public interface IReadRepository<T> where T:EntityBase,IEntityBase{
        T GetByID(int Id);
        IEnumerable<T> GetAll();
    }

    public interface IWriteRepository<T> where T:EntityBase,IEntityBase{
        void Add(T item);
        
        void Save();
        void Remove(T item);
    }


    public interface IRepository<T>:IReadRepository<T>,IWriteRepository<T> where T : EntityBase, IEntityBase
    {
        
        
    }
}