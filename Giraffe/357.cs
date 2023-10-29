using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Program { 
    public static void Main()
    {
        Double d;
        d = Char.GetNumericValue('\u0033');
        Console.WriteLine(d.ToString());
        d = Char.GetNumericValue('A');
        Console.WriteLine(d.ToString());
    }
}