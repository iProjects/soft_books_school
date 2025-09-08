using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public static class StringExtensions
    {
        /// <summary>
        /// VB Left function
        /// </summary>
        /// <param name="stringparam"></param>
        /// <param name="numchars"></param>
        /// <returns>Left-most numchars characters</returns>
        public static string Left(this string stringparam, int numchars)
        {
            // Handle possible Null or numeric stringparam being passed
            stringparam += string.Empty;
            // Handle possible negative numchars being passed
            numchars = Math.Abs(numchars);
            // Validate numchars parameter
            if (numchars > stringparam.Length)
                numchars = stringparam.Length;
            return stringparam.Substring(0, numchars);
        }
        /// <summary>
        /// VB Right function
        /// </summary>
        /// <param name="stringparam"></param>
        /// <param name="numchars"></param>
        /// <returns>Right-most numchars characters</returns>
        public static string Right(this string stringparam, int numchars)
        {
            // Handle possible Null or numeric stringparam being passed
            stringparam += string.Empty;
            // Handle possible negative numchars being passed
            numchars = Math.Abs(numchars);
            // Validate numchars parameter
            if (numchars > stringparam.Length)
                numchars = stringparam.Length;
            return stringparam.Substring(stringparam.Length - numchars);
        }
        /// <summary>
        /// VB Mid function - to end of string
        /// </summary>
        /// <param name="stringparam"></param>
        /// <param name="startIndex">VB-Style startindex, 1st char startindex = 1</param>
        /// <returns>Balance of string beginning at startindex character</returns>
        public static string Mid(this string stringparam, int startindex)
        {
            // Handle possible Null or numeric stringparam being passed
            stringparam += string.Empty;
            // Handle possible negative startindex being passed
            startindex = Math.Abs(startindex);
            // Validate numchars parameter
            if (startindex > stringparam.Length)
                startindex = stringparam.Length;
            // C# strings are zero-based, convert passed startindex
            return stringparam.Substring(startindex - 1);
        }
        /// <summary>
        /// VB Mid function - for number of characters
        /// </summary>
        /// <param name="stringparam"></param>
        /// <param name="startIndex">VB-Style startindex, 1st char startindex = 1</param>
        /// <param name="numchars">number of characters to return</param>
        /// <returns>Balance of string beginning at startindex character</returns>
        public static string Mid(this string stringparam, int startindex, int numchars)
        {
            // Handle possible Null or numeric stringparam being passed
            stringparam += string.Empty;
            // Handle possible negative startindex being passed
            startindex = Math.Abs(startindex);
            // Handle possible negative numchars being passed
            numchars = Math.Abs(numchars);
            // Validate numchars parameter
            if (startindex > stringparam.Length)
                startindex = stringparam.Length;
            // C# strings are zero-based, convert passed startindex
            return stringparam.Substring(startindex - 1, numchars);
        }
    }
}
