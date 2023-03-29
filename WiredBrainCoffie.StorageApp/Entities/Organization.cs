using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffie.StorageApp.Entities.Base;

namespace WiredBrainCoffie.StorageApp.Entities
{
    public class Organization:EntityBase
    {
        public string? Name {get;set;}
        
        public override string ToString()
        {
            return $"ID : {Id}, Name : {Name}";
        }
    }
}