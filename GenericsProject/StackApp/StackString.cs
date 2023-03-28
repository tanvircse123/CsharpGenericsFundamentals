using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericsProject.StackApp
{
    public class StackString
    {
        private string[] _items;
        private int currentIndex = 0;
        public StackString()
        {
            _items = new String[10];
        }
        public int Count(){
            return currentIndex;
        }
        public void push(string item){
            _items[currentIndex] = item;
            currentIndex++;

        }

        public string pop(){
            var item = _items[currentIndex -1];
            currentIndex--;
            return item;
        }

    }
}