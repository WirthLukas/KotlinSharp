using System;
using System.Collections.Generic;
using KotlinSharp;
using static KotlinSharp.K;

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

            //Repository? bsp = K.With(Repository.Instance, it =>
            //{
            //    it.Val1 = 1;
            //    it.Val2 = 2;
            //    it.Val3 = 3;
            //    return it;
            //}).TakeIf(it => it.Val1 == 1);

            Repository? bsp = With(Repository.Instance, it =>
            {
                it.Val1 = 1;
                it.Val2 = 2;
                it.Val3 = 3;
                return it;
            }).TakeIf(it => it.Val1 is 1);


            string? aNewText = bsp is null ? null : "Not null";

            aNewText?.Let(it => Console.WriteLine(aNewText));

            var list = new List<string>() {"A new moon", "collections", "the adventure", "not null"};

            foreach (var (index, value) in list.GetEnumerator().WithIndex())
            {
                Console.WriteLine($"{index.ToDouble()}: {value}");
            }

            var tu = new ValueTuple<int, int>(1, 2);
        }
    }
}