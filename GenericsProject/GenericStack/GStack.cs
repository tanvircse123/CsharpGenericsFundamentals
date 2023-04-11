using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericsProject.GenericStack
{
    public class GStack<T>
    {
        private T[] _items;
        private int _currentIndex = 0;
        public GStack()
        {
            _items = new T[10];
        }

        public int Count(){
            return _currentIndex;
        }
        public void push(T item){
            _items[_currentIndex] = item;
            _currentIndex++;
        }

        public T pop(){
            var item =  _items[_currentIndex -1];
            _currentIndex--;
            return item;

        }
    }
}