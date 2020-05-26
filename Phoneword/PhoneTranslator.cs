using System.Text;
using System;
namespace Core
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
            //^ method to convert the argument "raw" (string raw) = (user IP) to number 
        {
            if (string.IsNullOrWhiteSpace(raw))
                return " ";
                //^ check if argument "raw" is Null, Empty, or WhiteSpace if so return the WhiteSpace
            else 
                raw = raw.ToUpperInvariant();
                //^ else assign to argument "raw" the new value with all letters converted to uppercase 
                //^ ToUpperInvariant() returns the copy of argument "raw" string converted to uppercase

            var newNumber = new StringBuilder();
                //^ create the new instance "newNumber" of StringBuilder class (string)

            foreach (var c in raw)
                //^ chek each item "c" of argument "raw" ... 
            {
                if (" -0123456789".Contains(c))
                    //^ if list of characters and digits contains "c" item of argument "raw"
                    //^ if item "c" of argument "raw" is whitespace, -, or digit already 
                    //^ (what if it is other special character like "(", ")", or "+"
                {
                    newNumber.Append(c);
                    //^ if so add this current value of item "c" to the end of string "newNumber" 
                    //^ using method Append(c)
                    
                }//if (" -0123456789".Contains(c))

                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);

                }//else
                // otherwise we have skipped a non-numeric char

            }//foreach (var c in raw)

            return newNumber.ToString();

        }//public static string ToNumber(string raw)

        static bool Contains (this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }//static bool Contains (this string keyString, char c)

        static int? TranslateToNumber(char c)
        {
            if ("ABC".Contains(c))
                return 2;
            else if ("DEF".Contains(c))
                return 3;
            else if ("GHI".Contains(c))
                return 4;
            else if ("JKL".Contains(c))
                return 5;
            else if ("MNO".Contains(c))
                return 6;
            else if ("PQRS".Contains(c))
                return 7;
            else if ("TUV".Contains(c))
                return 8;
            else if ("WXYZ".Contains(c))
                return 9;
            return null;
        }//static int? TranslateToNumber(char c)

    }//public static class PhonewordTranslator

}// namespace Core