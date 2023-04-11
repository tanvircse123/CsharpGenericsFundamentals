using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericsProject.Extension;

namespace GenericsProject.CollectionGenericDemo
{
    public static class DefaultClass
    {
        public static void DefaultGenericsStack(){
            var stackString = new Stack<string>();
            stackString.Push("Tanvir");
            stackString.Push("Rahman");
            stackString.Push("Ornob");
            stackString.Push("Ornik");
            stackString.Push("Aaaron");
            Console.WriteLine("Total Item  = "+stackString.Count());
            var stackquery = stackString.AsQueryable();
            var stacklist = stackquery.ToList();
            // when you change the stack class to list
            // it values got reverse order
            stacklist.Reverse();
            while(stackString.Count > 0){
                var item = stackString.Pop();
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------");
            // now use extension method to make the pop method in the list item
            while(stacklist.Count>0){
                var item = stacklist.pop();
                Console.WriteLine(item);
            }


        }
        
    }
}