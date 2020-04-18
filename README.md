# KotlinSharp

This Library implements some of nice Functions of [Kotlin](https://kotlinlang.org/) in C#.
**I used the .Net Core 3.1 Framework** with [nullable types](https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/february/essential-net-csharp-8-0-and-nullable-reference-types)

## Scope Functions

The Extension Functions of a generic type are implemented in the [GeneralExtensions class](./KolinSharp/GeneralExtensions.cs)

All standalone functions are in the *"Kotlin"* class named [K](./KotlinSharp/K.cs)

## Examples

You can find all of these examples and more in the [ConsoleTests Project](./KotlinSharp/ConsoleTests).

### Singleton

Normally a implementation of a Singleton

```csharp
public class Repository
{
    private static Repository? _instance = null;
    private static readonly object Locker = new object();

    // Normally a Instance Property
    public static Repository Instance
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

    // Example Build Method
    private static Repository Build() => new Repository();

    private Repository()
    {}
}
```

Implementation in Kotlin Style

```csharp

public static Repository Instance
    => _instance ?? K.Synchronized(Locker, 
        () => _instance ?? Build().Also(it => _instance = it));

```

Implementation with C# 8 ??= Operator

```csharp
public static Repository InstanceX 
    => _instance ?? K.Synchronized(Locker, () => _instance ??= Build());
```

### Example Console Program

```csharp
class Program
{
    static void Main(string[] args)
    {
        string? test = null;
        Console.WriteLine($"Nullable: {test.ToStringK()}");     // Writes "Nullable: null"; raises no Exception!
        test = "with a value";
        Console.WriteLine($"Nullable: {test.ToStringK()}");     // Writes "Nullable: with a value"

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
```
