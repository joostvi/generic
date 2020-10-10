using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GenericClassLibrary.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceSpaceByUnderscore(this string input)
        {
            return input.Replace(" ", "_");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLine"></param>
        /// <param name="noTrime">When true do not remove trailing spaces</param>
        /// <returns></returns>
        public static string ReplaceDuplicateSpace(this string aLine, bool noTrime)
        {
            if (noTrime)
            {
                ///https://medium.com/factory-mind/regex-tutorial-a-simple-cheatsheet-by-examples-649dc1c3f285
                /// \b represents an anchor like caret (it is similar to $ and ^) matching positions where one side is a word character (like \w) and the other side is not a word character (for instance it may be the beginning of the string or a space character).
                /// \s = space
                /// {2,} = 2 or more times.
                return Regex.Replace(aLine, "\\b\\s{2,}\\b", " ");
            }
            return ReplaceDuplicateSpace(aLine);
        }

        public static string ReplaceDuplicateSpace(this string aLine)
        {
            ///https://medium.com/factory-mind/regex-tutorial-a-simple-cheatsheet-by-examples-649dc1c3f285
            /// \b represents an anchor like caret (it is similar to $ and ^) matching positions where one side is a word character (like \w) and the other side is not a word character (for instance it may be the beginning of the string or a space character).
            /// \s = space
            /// {2,} = 2 or more times.
            return Regex.Replace(aLine, "\\s{2,}", " ");
        }
    }
}
