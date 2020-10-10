using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClassLibrary.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceSpaceByUnderscore(this string input)
        {
            return input.Replace(" ", "_");
        }
    }
}
