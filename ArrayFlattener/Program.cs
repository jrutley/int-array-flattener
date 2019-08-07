using System;
using System.Linq;

namespace ArrayFlattener
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array = new dynamic[]{ new dynamic[]{1,2, new[]{3} }, 4};
            var expected = new[] {1,2,3,4};

            var sut = new Flattener();
            var result = sut.Flatten(array);
            if(!expected.SequenceEqual(result)) { Console.WriteLine("booooo"); } else { Console.WriteLine("yaaay"); }
        }
    }
}
