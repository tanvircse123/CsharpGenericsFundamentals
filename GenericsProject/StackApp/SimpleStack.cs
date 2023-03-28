namespace GenericsProject.StackApp
{
    public class SimpleStack{
        private double[] _items;
        private int _currentIndex = 0;
        public SimpleStack()
        {
            // init the array
            _items = new double[10];
        }

        public void push(double item){
            _items[_currentIndex] = item;
            _currentIndex++;

        }

        public int Count(){
            return _currentIndex;
        }

        public double pop(){
            var item =  _items[_currentIndex-1];
            _currentIndex--;
            return item;
        }
    }


    
}