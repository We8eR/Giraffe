using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Program358
{
    public static void Main()
    {
        Char c;
        Int32 n;
        c = (Char)65;
        Console.WriteLine(c);

        n = (Int32)c;
        Console.WriteLine(n);

        c = unchecked((Char)(65536 + 65));
        Console.WriteLine(c);

        c = Convert.ToChar(65);
        Console.WriteLine(c);

        n = Convert.ToInt32(c);
        Console.WriteLine(n);
        try {
            c = Convert.ToChar(70000);
            Console.WriteLine(c);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Can't convert 70000 to a Char");

        }
        c = ((IConvertible)65).ToChar(null);
        Console.WriteLine(c);

        n = ((IConvertible) c).ToChar(null);
        Console.WriteLine(n);
        }
    }
