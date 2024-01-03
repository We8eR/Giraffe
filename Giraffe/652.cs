using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Wintellect.HostSDk;

public static class Program
{
    public static void Main()
    {
        String AddInDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location);
        var AddInAssemblies = Directory.EnumerateFiles(AddInDir, "*.dll");
        var AddInTypes = from file in AddInAssemblies let assembly = Assembly.Load(file)
        from t in assembly.ExportedTypes
        where t.IsClass && typeof(IAddIn).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())
        select t;
    foreach (Type t in AddInTypes)
        {
            IAddIn ai = (IAddIn) Avtivator.CreateInstance(t);
            Console.WriteLine(ai.ToString(5));
        }
    }
}

