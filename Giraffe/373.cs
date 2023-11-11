using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Text.Json;

public sealed class Program373
{
    public static void Main() {
        String s = "a\u0304\u0308bc\u0327";
        SubstringByTextElements(s);
        EnumTextElements(s);
        EnumTextElementIndexes(s);
    }
    private static void SubstringByTextElements(String s)
    {
        String output = String.Empty;
    }
    StringInfo stringInfo = new StringInfo(s);
    for (Int32 element = 0; element < si.LengthInTextElements; element++){
        output += String.Format("Text element {0} is '{1}'{2}",
        element, si.SubstringByTextElements(element, 1), Environment.NewLine);
}
MessageBox.Show(output, "Result of SubstringByTextElements");
}

private static void EnumTextElementIndexes(String s)
{
    String output = String.Empty;

    Int32[] textElemIndex = StringInfo.ParseCombiningCharacters(s);
    for (Int32 i = 0; i < textElemIndex.Length; i++)
    {
        output += String.Format("Character {0] starts at index {1}{2}", i,
            textElemIndex[i], Environment.NewLine);

    }
    MessageBox.Show(output, "Result of ParseCombiningCharacters");
  }
}