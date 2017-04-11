using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
   class SpecialDigit
   {
      public static string getDigit(int iPosition) { return digit[iPosition];}   
      static string[] digit = new string[] { "~",
                                             "!",
                                             "#",
                                             "$",
                                             "%",
                                             "^",
                                             "&",
                                             "*",
                                             "(",
                                             ")",
                                             "-",
                                             "=",
                                             "+",
                                             "[",
                                             "]",
                                             "\\",
                                             "{",
                                             "}",
                                             ":",
                                             ";",
                                             "\"",
                                             "'",
                                             "<",
                                             ">",
                                             "?",
                                             "//",
                                             "@",
                                             "_",
                                             "|",
                                             "ç",
                                             "`",
                                             "£",
                                             "¢",
                                             "ª",
                                             "º",
                                             "°"};
   }
}
