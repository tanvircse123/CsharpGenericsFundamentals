using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericsProject.Extension
{
    public static class ListExtension
    {
        public static T pop<T>(this List<T> mylist){

            if(mylist.Count == 0){
                throw new InvalidOperationException("List Is Empty");
            }
            int lastIndex = mylist.Count -1;
            T item = mylist[lastIndex];
            mylist.RemoveAt(lastIndex);
            return item;

        }
    }
}