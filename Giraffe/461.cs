using System;
using System.Reflection;
using System.IO;

internal delegate Object TwoInt32s(Int32 n1, Int32 n2);
internal delegate Object OneString(String s1);

public static class DelegateReflection
{
    public static void Main(String[] args)
    {
        if (args.Length < 2) {
            String usage =
                @"Usage:" +
                "{0} delType methodName [Arg1] [Arg2]" +
                "{0} where delType must be TwoInt32s or OneString" +
                "{0} if deltype is TwoInt32s, methodName must be Add or Subsract" +
                "{0} if delType is OneString, methodName must be NumChars or Reverse"

                "{0}" +
                "{0}Examples:" +
                "{0}  TwoInt32s Add 123 321" +
                "{0}  TwoInt32s Substract 123 321" +
                "{0}  OneString NumChars \"Hello there\"" +
                "{0}  OneString Reverse \"Hello there\"";
                Console.WriteLine(usage, Environment.NewLine);
                return
        }
        Type delType = Type.GetType(args[0]);
        if (delType == null )
        {
            Console.WriteLine("Invalid delType argument: " + args[0]);
            return;
        }
    }
}