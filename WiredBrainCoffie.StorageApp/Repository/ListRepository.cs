using WiredBrainCoffie.StorageApp.Entities.Base;

namespace WiredBrainCoffie.StorageApp.Repository
{

    /* the T:EntityBase Says that you can add type any genericn type
   but that also have to inherit from the Entity base so that 
   the property of the entity type will be there
*/
    public class ListsRepository<T> : IRepository<T> where T : EntityBase, IEntityBase

    {

        protected List<T> _items;

        public ListsRepository()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            item.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(item);
        }

        public void Save()
        {
            
            Console.WriteLine("Data Saved");


        }

        public T GetByID(int Id)
        {
            return _items.Single(x => x.Id == Id);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
    }
}