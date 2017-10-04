using System;

namespace DecoratorAdapter
{
    public class Demo
    {
        static void Main(string[] args)
        {
            MyStringBuilder s = "hello ";
            s += "world"; // will work even without op+ in MyStringBuilder
            // why? you figure it out!
            Console.WriteLine(s);
        }
    }
}