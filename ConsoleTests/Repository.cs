using System.Collections.Generic;
using KotlinSharp;

namespace ConsoleTests
{
    public class Repository
    {
        #region <<static members>>

        private static Repository? _instance = null;
        private static readonly object Locker = new object();

        private static Repository Build() => new Repository();

        #region MyRegion

        // Common Instance implementation
        //public static Repository Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (Locker)
        //            {
        //                if (_instance == null)
        //                    _instance = Build();
        //            }
        //        }

        //        return _instance;
        //    }
        //}

        //// With Methods from the Kotlin implementation
        //public static Repository Instance
        //    => _instance ?? K.Synchronized(Locker,
        //        () => _instance ?? Build()
        //            .Also(it => _instance = it));

        // new ??= operator
        public static Repository Instance
            => _instance ?? K.Synchronized(Locker, () => _instance ??= Build());

        #endregion

        #endregion

        private readonly List<int> _items = new List<int>();

        public int Count => _items.Count;
        public IEnumerable<int> Items => _items;

        private Repository()
        {
            
        }

        public void Add(int item)
            => _items.Add(item);

        public void AddRange(params int[] items)
        {
            foreach (var item in items)
            {
                Add(item);    
            }
        }

        public override string ToString()
        {
            return $"Repository: {{ {_items.JoinToString()} }}";
        }
    }
}