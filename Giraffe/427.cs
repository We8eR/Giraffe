using System;
public sealed class Program
{
    public static void Main()
    {
        Array a;
        a = new String[0];
        Console.WriteLine(a.GetType());
        a = Array.CreateInstance(typeof(String), new Int32[] { 1 });
        Console.WriteLine(a.GetType());

        Console.WriteLine();
        a = new String[0, 0];
        Console.WriteLine(a.GetType());
        a = Array.CreateInstance(typeof(String), new Int32[] { 1, });
        Console.WriteLine(a.GetType());
        Console.WriteLine();
        a = new String[0, 0];
        Console.WriteLine(a.GetType());

        a = Array.CreateInstance(typeof (String), new Int32[] { 0, 0 }, new Int32[] {0, 0});
        Console.WriteLine(a.GetType());

        a = Array.CreateInstance(typeof(String), new Int32[] { 0, 0 }, new Int32[] { 1, 1 });
        Console.WriteLine(a.GetType());
    }
}