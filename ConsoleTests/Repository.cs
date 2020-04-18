using KotlinSharp;

namespace ConsoleTests
{
    public class Repository
    {
        private static Repository? _instance = null;
        private static readonly object Locker = new object();

        public static Repository CommonInstanceCall
        {
            get 
            {
                if (_instance == null)
                {
                    lock(Locker)
                    {
                        if (_instance == null)
                            _instance = Build();
                    }
                }

                return _instance;
            }
        }

        // With Methods from the Kotlin implementation
        public static Repository Instance
            => _instance ?? K.Synchronized(Locker, 
                () => _instance ?? Build()
                    .Also(it => _instance = it));

        public static Repository InstanceX
            => _instance ?? K.Synchronized(Locker, () => _instance ??= Build());


        private static Repository Build() => new Repository();

        public int Val1 { get; set; }
        public int Val2 { get; set; }
        public int Val3 { get; set; }

        private Repository()
        {
            
        }

        public override string ToString()
        {
            return "yeah, a Repo! :D";
        }
    }
}