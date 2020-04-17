using System;
using KotlinSharp;

#nullable enable

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string? test = null;
            Console.WriteLine($"Nullable: {test.ToStringK()}");
            test = "with a value";
            Console.WriteLine($"Nullable: {test.ToStringK()}");

            /*long length = new FileStream("test.txt", FileMode.OpenOrCreate).Use(fs =>
            {
                Console.WriteLine($"File: {fs.Name}");
                return fs.Length;
            });*/
            
            // Repository r = Repository.Instance;
            // Console.WriteLine($"Repository: {r.ToStringK()}");

            Repository.Instance.Let(it => Console.WriteLine($"Repository: {it.ToStringK()}"));
            
            var aVeryLongNameForRepository = Repository.Instance;
            K.With(aVeryLongNameForRepository, (Repository it) =>
            {
                it.Val1 = 1;
                it.Val2 = 2;
                it.Val3 = 3;
            });

            Repository? bsp = K.With(Repository.Instance, it =>
            {
                it.Val1 = 1;
                it.Val2 = 2;
                it.Val3 = 3;
                return it;
            }).TakeIf(it => it.Val1 == 1);
        }
    }
}