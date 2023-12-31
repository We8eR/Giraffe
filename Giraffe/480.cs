using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

[assembly: CLSCompliant(true)]

[Serializable]
[DefaultMemberAttribute("Main")]
[DebuggerDisplayAttribute("Richter", Name = "Jeff", Target = typeof(Program))]
public sealed class Program
{
    [Conditional("Debug")]
    [Conditional("Release")]
    public void DoSomething() { }

    public Program()
    {

    }
    [CLSCompliant(true)]
    [STAThread]
    public static void Main()
    {
        ShowAttributes(typeof(Program));
        MemberInfo[] members = typeof(Program).FindMembers(
            MemberTypes.Constructor | MemberTypes.Method,
            BindingFlags.DeclaredOnly | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.Static, Type.FilterName, "*");
        foreach (MemberInfo member in members)
        {
            ShowAttributes(member);
        }
    }
    private static void ShowAttributes(MemberInfo attributeTarget)
    {
        IList<CustomAttributeData> attributes = attributeTarget.GetCustomAttributes(attributeTarget);
        Console.WriteLine("Attributes applied to {0}: {1}", attributesTarget.Name, (attributes.Count == 0 ? "None" : String.Empty));
        foreach (CustomAttributeData attribute in attributes)
        {
            Type t = attribute.Constructor.DeclaringType;
            Console.WriteLine(" {0}", t.ToString());
            Console.WriteLine(" Construction called={0}", attribute.Constructor);

            IList<CustomAttributeTypedArgument> posArgs = attribute.ConstructorArguments;
            Console.WriteLine(" Positional arguments passed to constructor:" + ((posArgs.Count == 0) ? " None" : String.Empty));
            foreach(CustomAttributeTypedArgument pa in posArgs)
            {
                Console.WriteLine(" Type={0}, Value={1}", pa.ArgumentType, pa.Value);
            }
            IList<CustomAttributeNamedArgument> namedArgs = attribute.NamedArguments;
            Console.WriteLine(" Named arguments set after construction:" + ((namedArgs.Count == 0) ? " None" : String.Empty));
            foreach(CustomAttributeNamedArgument na in namedArgs)
            {
                Console.WriteLine(" Name={0}, Type={1}, Value={2}, na.MemberInfo.Name, na.TypedValue.ArgumentType, na.TypedValue.Value");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
