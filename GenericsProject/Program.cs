using GenericsProject.StackApp;

//StackDouble();
StackString();

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