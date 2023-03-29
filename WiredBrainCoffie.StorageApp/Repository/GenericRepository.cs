using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffie.StorageApp.Entities;
using WiredBrainCoffie.StorageApp.Entities.Base;

namespace WiredBrainCoffie.StorageApp.Repository
{
    /* the T:EntityBase Says that you can add type any genericn type
        but that also have to inherit from the Entity base so that 
        the property of the entity type will be there
    */
    public class GenericRepository<T> where T:IEntityBase

    {
        
        protected List<T> _items;

        public GenericRepository()
        {
            _items = new List<T>();
        }

        public void Add(T item){
            item.Id = _items.Any()?_items.Max(item=>item.Id) +1:1;
            _items.Add(item);
        }

        public void Save(){
            foreach(var item in _items){
                Console.WriteLine(item); // the Tostring Overright will show here
            }
        }

        public T GetByID(int Id){
            return _items.Single(x=>x.Id == Id);
        }

        


    }
}