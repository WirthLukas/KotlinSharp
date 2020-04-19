using System;
using System.Collections.Generic;
using System.Linq;
using KotlinSharp;
// using static KotlinSharp.K;      // with this you can write With(...) instead of K.With()

#nullable enable

namespace ConsoleTests
{
    static class Program
    {
        private static void Main(string[] args)
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

            //RepositoryTests();
            
            //IndexedIteratorTest();

            //TupleTest();

            ForeachTest();
        }


        private static void TupleTest()
        {
            var tuple = (1, 10, 18);
            Console.WriteLine($"Tuple: {tuple.ToList().JoinToString()}");
        }

        private static void IndexedIteratorTest()
        {
            var list = new List<string>() { "A new moon", "collections", "the adventure", "not null" };

            foreach (var (index, value) in list.GetEnumerator().WithIndex())
            {
                Console.WriteLine($"{index.ToDouble()}: {value}");
            }
        }

        private static void RepositoryTests()
        {
            // Repository r = Repository.Instance;
            // Console.WriteLine($"Repository: {r.ToStringK()}");

            Repository.Instance
                .Let(it => Console.WriteLine($"Repository: {it.ToStringK()}"));


            //var aVeryLongNameForRepository = Repository.Instance;
            //K.With(aVeryLongNameForRepository, (Repository it) =>
            //{
            //    it.AddRange(1, 3, 5, 7, 9, 10, 4);
            //});

            Repository? bsp = K.With(Repository.Instance, it =>
            {
                it.AddRange(1, 3, 5, 7, 9, 10, 4);
                return it;
            }).TakeIf(it => it.Count > 4);

            Console.WriteLine($"Is it a good Repository? {bsp.ToStringK()}");

            string? aNewText = bsp is null ? null : "Not null";
            aNewText?.Let(Console.WriteLine);

            string? aNewString = (bsp is null ? null : "Not null")?.Let(it =>
            {
                Console.WriteLine(it);
                return it;
            });
        }

        private static void ForeachTest()
        {
            Repository.Instance.AddRange((1..10000).ToList().ToArray());

            Repository.Instance.Items
                .Where(x => x > 5000)
                .OrderBy(x => x)
                .Take(5)
                .ForEach( x => Console.Write($"{x}, "));

            Console.WriteLine();

            Repository.Instance.Items
                .Where(x => x > 5000)
                .OrderBy(x => x)
                .TakeLast(5)
                .ForEachIndexed((i, x) => Console.WriteLine($"{i}: {x} "));
        }

        private static List<int> ToList(this Range range)
        {
            var list = new List<int>();

            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}