using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffie.StorageApp.Entities.Base;

namespace WiredBrainCoffie.StorageApp.Repository
{
    public class GenericRepositoryWithRemove<T>:GenericRepository<T> where T:EntityBase,IEntityBase
    {
        public void Remove(T item){
            _items.Remove(item);
        }
        
    }
}