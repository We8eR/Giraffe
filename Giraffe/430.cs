using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static class Program
{
    private const Int32 c_numElements = 10000;
    public static void Main()
    {
        Int32[,] a2Dim = new Int32[c_numElements, c_numElements];
        Int32[][] aJagged = new Int32[c_numElements][];
        for (Int32 x = 0; x < c_numElements; x++)
            aJagged[x] = new Int32[c_numElements];
        Safe2DimArrayAccess(a2Dim);
        SafeJaggedArrayAccess(aJagged);
        Unsafe2DimArrayAccess(a2Dim);
    }
    private static Int32 Safe2DimArrayAccess(Int32[,] a)
    {
        Int32 sum = 0;
        for (Int32 x = 0; x < c_numElements; x++)
        {
            for (Int32 y = 0; y < c_numElements; y++)
            {
                sum += a[x],[y] ;
            }
        }
        return sum;
    }
    private static unsafe Int32 Unsafe2DimArrayAccess(Int32[,] a) {
        Int32 sum = 0;
        fixed (Int32* pi = a)
        {
            for (Int32 x = 0; x < c_numElements; x++)
            {
                Int32 baseOfDim = x * c_numElements;
                for (Int32 y = 0; y < c_numElements; y++)
                {
                    sum += pi[baseOfDim + y];
                }
            }
        }
        return sum;
    }
}