using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffie.StorageApp.Entities.Base;
using WiredBrainCoffie.StorageApp.Repository;

namespace WiredBrainCoffie.StorageApp.Extension
{
    public static class RepositoryExtension
    {
        public static void AddbatchEx<T>(this IRepository<T> repo,T[] items) where T:EntityBase{
            foreach(var item in items){
                repo.Add(item);
            }
            repo.Save();
            Console.WriteLine("Added From the Extension");
        }
    }
}