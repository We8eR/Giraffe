using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    internal struct MyValueType : IEquatable
    {
        public Int32 CompareTo(Object obj)
        {

        }
    }
    public static class Program
    {
        public static void Main()
        {
            MyValueType[] src = new MyValueType[100];
            IComparablep[] dest = new IComparable[src.Length];
            Array.Copy(src, dest, src.Length);
        }
    }
}
