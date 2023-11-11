using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;


public sealed class Program367
{
    public static void Main()
    {
        String output = String.Empty;
        String[] symbol = new String[] { "<", "=", ">" };
        Int32 x;
        CultureInfo ci;
        String s1 = "coté";
        String s2 = "côte";

        ci = new CultureInfo("fr-FR");
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;

        ci = new CultureInfo("ja-JP");
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;
        ci = Thread.CurrentThread.CurrentCulture;
        x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
        output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine + Environment.NewLine;


        s1 = " ";
        s2 = " ";

        ci = new CultureInfo("ja-JP");
        x = Math.Sign(String.Compare(s1, s2, true, ci));
        output += String.Format("Simple {0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
        output += Environment.NewLine;

        CompareInfo compareInfo = CompareInfo.GetCompareInfo("ja-JP");
        x = Math.Sign(compareInfo.Compare(s1, s2, CompareOptions.IgnoreKanaType));
        output += String.Format("Advanced {0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);

        MessageBox.Show(output, "Comparing Strings For Sorting");


    }


}   
