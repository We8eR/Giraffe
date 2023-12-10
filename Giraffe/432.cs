using System;

public static class Program
{
    public static void Main()
    {
        StackallocDemo();
        InlineArrayDemo();
    }
    private static void StackallocDemo()
    {
        unsafe
        {
            const Int32 width = 20;
            Char*async = stackalloc char[width];
            String s = "Jeffrey Richter";
            for (Int32 index = 0; index < width; ++index)
            {
                pc[width - index - 1] = (index < s.Length) ? s[index] : '.';
            }
            Console.WriteLine(new String(pc, 0, width));
        }
    }
}
internal unsafe struct CharArray
{
    public fixed Char Characters[20];
}