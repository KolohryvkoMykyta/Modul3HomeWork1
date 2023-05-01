using Modul3HomeWork1;

MyList<int> myList = new MyList<int>();

List<int> ints = new List<int>();

for (int i = 0; i < 20; i++)
{
    ints.Add(i);
    myList.Add(i);
}

myList.AddRange(ints);
myList.Add(-2);
myList.Add(-8);

bool one = myList.Remove(0);
bool two = myList.Remove(0);
bool tree = myList.Remove(0);

foreach (var item in myList)
{
    Console.WriteLine(item);
}

Console.WriteLine(one);
Console.WriteLine(two);
Console.WriteLine(tree);

myList.RemoveAt(0);
myList.RemoveAt(myList.Length - 1);

foreach (var item in myList)
{
    Console.WriteLine(item);
}

myList.Sort();

foreach (var item in myList)
{
    Console.WriteLine(item);
}