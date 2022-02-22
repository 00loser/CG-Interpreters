using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interpreters.Utils
{
    internal static class Utility
    {
        private const string AllowedChars = "><+-.,[]";

        internal static int ParseHex(string s) =>
              Convert.ToInt32(s, 16);
        internal static int ParseHex(char s) =>
             Convert.ToInt32(s.ToString(), 16);

        internal static List<string> Chunks(this string input, int amount)
        {
            StringBuilder sb = new StringBuilder(input.Length / amount);
            for (int i = 0; i < input.Length; sb.Append(input[i]), i++)
                if (i != 0 && i % amount == 0)
                    sb.Append(" ");
            return sb.ToString().Split(" ").ToList();
        }

        internal static string Sanitize(this string input)
        {
            var result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                if (AllowedChars.Contains(input[i].ToString()))
                    result.Append(input[i]);
            return result.ToString();
        }

        internal static Dictionary<int, int> FindPairs(this string code)
        {
            List<int> open = new List<int>(),
            closed = new List<int>();

            for (int i = 0; i < code.Length; i++)
                if (code[i] == '[')
                    open.Add(i);
            for (int i = 0; i < code.Length; i++)
            {
                int n = i == 0 ? code.LastIndexOf(']') : code.IndexOf(']', i);
                if (n != -1 && !closed.Contains(n))
                    closed.Add(n);
            }
            //merge lists
            return open.Zip(closed, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        }
    }
}
