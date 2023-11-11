using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

public static class Program360
{
    public static void Main()
    {
        String s1 = "Strasse";
        String s2 = "Straße";
        Boolean eq;

        eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
        Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");
        CultureInfo ci = new CultureInfo("de-DE");

        eq = String.Compare(s1, s2, true, ci) == 0;
        Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");
    }
}

