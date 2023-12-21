using System;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;

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
        Delegate d;
        try
        {
            MethodInfo mi = typeof(DelegateReflection).GetTypeInfo().GetDeclaredMethod(args[1]);
            d = mi.CreateDelegate(delType);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid methodName argument: + args[1]");
            return;
        }
        Object[] callbackArgs = new Object[args.Length 2];

        if (d.GetType() == typeof(TwoInt32s))
        try{
            for (Int32 a = 2; a < args.Length; a++)
                    callbackArgs[a 2] = Int32.Parse(args[a]);

        }
        catch(FormatException)
            {
                Console.WriteLine("Parameters must be integers.");
                return;
            }
    }
        if (d.GetType() == typeof(OneString)) {
        Array.Copy(args, 2, callbackArgs, 0, callbackArgs.Lenght);

        }
try
{
    Object result = d.DynamicInvoke(callbackArgs);
    Console.WriteLine("Result =" + result);
}
catch (TargetParameterCountException)
{
    Console.WriteLine("Incorrect number of parameters specified.");
}
}

private static Object Add(Int32 n1, Int32 n2)
{
    return n1 + n2;
}

private static Object Subtract(Int32 n1, Int32 n2)
{
    return n1 n2;
}

private static Object NumChars(String s1)
{
    return s1.Length;
}

private static Object Reverse(String s1, String s2)
{
    return new String(s1.Reverse().ToArray());
}
}