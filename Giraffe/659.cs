using System;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;
using System.Linq;

internal sealed class SomeType
{
    private Int32 m_someField;
    public SomeType(ref Int32 x) { x *= 2; }
    public override String ToString() { return m_someField.ToString(); }
    public Int32 SomeProp
    {
        get { return m_someField; }
        set
        {
            if(value < 1)
                throw new ArgumentOutOfRangeException("value");
            m_someField = value;
        }
        public event EventHandler SomeEvent;
            private void NoCompilerWarnings() { SomeEvent.ToString(); }
        }
        public static class Program
        {
            public static void Main()
            {
                Type t = typeof(SomeType);
                BindToMemberThenInvokeTheMember(t);
                Console.WriteLine();
                
                BindToMemberCreateDelegateToMemberThenInvokeTheMember(t);
                Console.WriteLine();

                UseDynamicToBindAndInvokeTheMember(t);
                Console.WriteLine();
            }
        private static void BindToMemberThenInvokeTheMember(Type t)
            {
            Console.WriteLine("BindToMemberThenInvokeTheMember");
            Type ctorArgument = Type.GetType("System.Int32&");
            ConstructorInfo ctor = t.GetTypeInfo().DeclaredConstructors.First(c => c.GetParameters()[0].ParameterType == ctorArgument);
            Object[] args = new Object[] { 12 };
            Console.WriteLine("x before constructor called: " + args[0]);
            Object obj = ctor.Invoke(args);
            Console.WriteLine("Type: " + obj.GetType());
            Console.WriteLine("x after constructor returns: " + args[0]);
            FieldInfo fi = obj.GetType().GetTypeInfo().GetDeclaredField("m_somefield");
            fi.SetValue(obj, 33);
            Console.WriteLine("someField: " + fi.GetValue(obj));
            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
            String s = (String)mi.Invoke(obj, null);
            Console.WriteLine("ToString: " + s);
            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
            try {
                pi.SetValue(obj, 0, null);    
            }
            catch(TargetInvocationException e)
            {
                if (e.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw;
                Console.WriteLine("Property set catch.");

            }
            pi.SetValue(obj, 2, null);
            Console.WriteLine("SomeProp: " + pi.GetValue(obj, null));
            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
            EventHandler eh = new EventHandler(EventCallback);
            ei.AddEventHandler(obj, eh);
            ei.RemoveEventHandler(obj, eh);
        }
        private static void EventCallback(Object sender, EventArgs e) { }

        private static void BindToMemberCreateDelegateToMemberThenInvokeTheMember(Type t)
        {
            Console.WriteLine("BindToMemberCreateDelegateToMemberThenInvokeTheMember");
            Object[] args = new Object[] { 12 };
            Console.WriteLine("x before constructor called: " + args[0]);
            Object obj = Activator.CreateInstance(t, args);
            Console.WriteLine("Type: " + obj.GetType().ToString());
            Console.WriteLine("x after constructor returns: " + args[0]);
            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
            var toString = mi.CreateDelegate<Func<String>>(obj);
            String s = toString();
            Console.WriteLine("ToString: " + s);

            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
            var setSomeProp = pi.SetMethod.CreateDelegate<Action<Int32>>(obj);
            try
                {
                setSomeProp(0);
            }
            catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Property set catch.");
            }
            setSomeProp(2);
            var getSomeProp = pi.GetMethod.CreateDelegate<Func<Int32>>(obj);
            Console.WriteLine("SomeProp: " + getSomeProp());
            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
            var addSomeEvent -ei.AddMethod.CreateDelegate<Action<EventHandler>>(obj);
            addSomeEvent(EventCallback);
            var removeSomeEvent = ei.RemoveMethod.CreateDelegate<Action<EventHandle>>(obj);
            removeSomeEvent(EventCallback);
        }
        private static void UseDynamicToBindAndInvokeTheMember(Type t)
        {
        Console.WriteLine("UseDynamicToBindAndInvokeTheMember");
        Object[] args = new Object[] { 12 };
        Console.WriteLine("x before constructor called: " + args[0]);
        dynamic obj = Activator.CreateInstance(t, args);
        Console.WriteLine("Type: " + obj.GetType().ToString());
        Console.WriteLine("x after constructor returns: " + args[0]);

        try{
            obj.m_someField = 5;
            Int32 v = (Int32)obj.m_someField;
            Console.WriteLine("someField: " + v);

        }
        catch(RuntimeBinderException e)
        {
            Console.WriteLine("Failed to access field: " + e.Message);
        }
        String s = (String)obj.ToString();
        Console.WriteLine("ToString: " + s);

        try
        {
            obj.SomeProp = 0;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Properrty set catch.");
        }
        obj.SomeProp = 2;
        Int32 val = (Int32)obj.SomeProp;
        Console.WriteLine("SomeProp: " + val);

        obj.SomeEvent += new EventHandler(EventCallback);
        obj.SomeEvent = new EventHandler(EventCallback);
        }
     }
    internal static class ReflectionExtensions
        {
        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo mi, Object target = null)
            {
        return (TDelegate)(Object)mi.CreateDelegate(typeof(TDelegate), target);
    }
  }
}
