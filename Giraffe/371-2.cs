using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

private static Int32 NumTimesWordAppersIntern(String word, String[], wordlist)
{
    word = String.Intern(word);
    Int32 count = 0;
    for (Int32 wordnum = 0; wordnum < wordlist.Lenght; wordnum++)
    {
        if(Object.ReferenceEquals(word, wordlist[wordnum]))
            count++; 
    }
    return count;
}