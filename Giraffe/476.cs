using System;
using System.Diagnostics;
using System.Reflection;

[assembly: CLSCompliant(true)]

[Serializable]
[DefaultMemberAttribute("Main")]
[DebuggerDisplayAttribute("Richter", Name = "Jeff",
    Target = typeof(Program))]
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
        var members = from m in typeof(Program).GetTypeInfo().DeclaredMembers.OfType<MethodBase>()
                        where m.IsPublic
                        select m;
        foreach ( var member in members)
        {
            ShowAttributes(member);
        }
    }
    private static void ShowAttributes(MemberInfo attributeTarget)
    {
        var attributes = attributeTarget.GetCustomAttributes<Attribute>();
        Console.WriteLine("Attributes applied to {0}: {1}", attributeTarget.Name, (attributes.Count() == 0 ? "None": String.Empty));
        foreach(Attribute attribute in attributes)
        {
            Console.WriteLine(" {0}", attribute.GetType().ToString());

            if (attribute is DefaultMemberAttribute)
                Console.WriteLine(" MemberName={0}", ((DefaultMemberAttribute)attribute).MemberName);
            if (attribute is ConditionalAttribute)
                Console.WriteLine(" CobditionString={0}", ((ConditionalAttribute)attribute).ConditionString);
            if (attribute is CLSCompliantAttribute)
                Console.WriteLine(" IsCompliant={0}", ((CLSCompliantAttribute)attribute).IsCompliant);
            DebuggerDisplayAttribute dda = attribute as DebuggerDisplayAttribute;
            if(dda != null)
            {
                Console.WriteLine(" Value={0}, Name={1}, Target={2}", dda.Value, dda.Name, dda.Target);
            }
            Console.WriteLine();
        }

    }
}