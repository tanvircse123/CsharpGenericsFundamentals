using GenericsProject.GenericStack;
using GenericsProject.StackApp;
using GenericsProject.CollectionGenericDemo;
StackDouble();
StackString();
GenericsclassDemo();
DefaultClass.DefaultGenericsStack();

void StackString()
{
    var stack = new StackString();
    stack.push("Tanvir");
    stack.push("Ornob");
    stack.push("Ornik");
    stack.push("Aaaron");
    while(stack.Count()>0){
        var item = stack.pop();
        Console.WriteLine("Item  = "+item);
    }
    Console.ReadLine();
    
}

static void StackDouble()
{
    var stack = new SimpleStack();
    stack.push(10.0);
    stack.push(20.0);
    stack.push(30.0);
    stack.push(40.0);
    // Console.WriteLine("Total Value = "+stack.Count());
    // Console.WriteLine("Popping "+stack.pop());
    // Console.WriteLine("Total Value = "+stack.Count());
    // Console.WriteLine("Popping "+stack.pop());
    // Console.WriteLine("Total Value = "+stack.Count());
    // Console.WriteLine("Popping "+stack.pop());
    // Console.WriteLine("Total Value = "+stack.Count());
    // Console.WriteLine("Popping "+stack.pop());
    // Console.WriteLine("Total Value = "+stack.Count());
    var sum = 0.0;
    while (stack.Count() > 0)
    {
        var item = stack.pop();
        Console.WriteLine("Item = " + item);
        sum += item;
    }

    Console.WriteLine("Total Value " + sum);
}


static void GenericsclassDemo(){
    var stackstring = new GStack<string>();
    var stackInt = new GStack<int>();

    stackstring.push("Tanvir");
    stackstring.push("ornob");
    stackstring.push("ornik");
    stackstring.push("aaaron");
    while(stackstring.Count()>0){
        var item = stackstring.pop();
        Console.WriteLine(item);
    }

    stackInt.push(1);
    stackInt.push(2);
    stackInt.push(3);
    stackInt.push(4);
    while(stackInt.Count()>0){
        var item = stackInt.pop();
        Console.WriteLine(item);
    }


}
