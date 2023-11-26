using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public static class DynamicArrays
{
    public static void Main()
    {
        Int32[] lowerBounds = { 2005, 1 };
        Int32[] lengths = { 5, 4 };
        Decimal[,] quaterlyRevenue = (Decimal[,])
            Array.CreateInstance(typeof(Decimal), lengths, lowerBounds);

        Console.WriteLine("{0,4} {1,9} {2,9} {3,9} {4,9}", "Year", "Q1", "Q2", "Q3", "Q4");
        Int32 firstYear = quaterlyRevenue.GetLowerBound(0);
        Int32 lastYear = quaterlyRevenue.GetUpperBound(0);
        Int32 firstQuater = quaterlyRevenue.GetLowerBound(1);
        Int32 lastQuater = quaterlyRevenue.GetUpperBound(1);

        for (Int32 year =  firstYear; year <= lastYear; year++)
        {
            Console.Write(year + " ");
            for (Int32 quarter = firstQuater;
                quarter <= lastQuater; quarter++)
            {
                Console.Write("{0,9:С}", quaterlyRevenue[year, quarter]);
            }
            Console.WriteLine();
        }
    }


}
