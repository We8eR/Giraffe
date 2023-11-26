using System;
using System.Security;
using System.Runtime.InteropServices;

public static class Program401
{
    public static void Main()
    {
        using (SecureString ss = new SecureString())
        {
            Console.Write("Please enter password: ");
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter) break;
                ss.AppendChar(cki.KeyChar);
                Console.Write("*");
            }
            Console.WriteLine();

            DisplaySecureString(ss);
        }
    }
    private unsafe static void DisplaySecureString(SecureString ss)
    {
        Char* pc = null;
        try
        {
            pc = (Char*)Marshal.SecureStringToCoTaskMemUnicode(ss);
            for (Int32 index = 0; pc[index] != 0; index++)
                Console.Write(pc[index]);
        }
        finally
        {
            if (pc != null)
                Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);

        }
    }
}
