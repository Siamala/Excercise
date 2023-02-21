using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Excercise_1
{
    public static class StringHelper
    {
        private static readonly Regex _hexStringPattern = new Regex(@"^(0[xX])?[A-Fa-f0-9]+$");
        private static readonly string _hexStringPatternWithDelimeter = @"(\<replaceMe>?([a-fA-F0-9][a-fA-F0-9])\<replaceMe>?)+";

        /// <summary>
        /// Convert hex string to byte array.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when input string is not a valid hex string.</exception>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string input)
        {
            if (input.Length % 2 == 1)
            {
                throw new ArgumentException($"Error converting hex string to byte array. Input hex string must have even length. String: {input}");
            }

            if (!_hexStringPattern.IsMatch(input))
            {

                throw new ArgumentException($"Error converting hex string to byte array. Input is not a valid hex string. String: {input}");
            }

            if (input.StartsWith("0x") || input.StartsWith("0X"))
            {
                input = input.Remove(0, 2);
            }

            // Inefficient
            return Enumerable.Range(0, input.Length / 2)
                             .Select(x => Convert.ToByte(input.Substring(x * 2, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Checks if provided <paramref name="input"/> with <paramref name="separator"/> can be parsed successfully as a hex bytes array 
        /// and returns <paramref name="byteArray"/> in case of success
        /// </summary>
        /// <param name="input"></param>
        /// <param name="separator"></param>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static bool TryParseHexStringWithSeparatorToByteArray(this string input, char separator, out byte[] byteArray)
        {
            byteArray = null;

            if (ValidateHexString(input, separator))
            {
                byteArray = HexStringWithSeparatorToByteArray(input, separator);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add another <paramref name="directoryName"/> to the path before file name
        /// </summary>
        /// <param name="input"></param>
        /// <param name="directoryName"></param>
        /// <returns>File path with additional folder before file name</returns>
        public static string AddDirectoryToPathFile(this string input, string directoryName)
        {
            if (!string.IsNullOrWhiteSpace(directoryName))
            {
                return Path.Combine(Path.GetDirectoryName(input), directoryName, Path.GetFileName(input));
            }
            else
            {
                return input;
            }
        }

        /// <summary>
        /// Returns <paramref name="fileName"/> with all invalid Windows file name characters removed
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string RemoveInvalidFileNameCharacters(this string fileName)
        {
            string newFileName = fileName;

            Path.GetInvalidFileNameChars()
                .ToList()
                .ForEach((c) => newFileName = newFileName.Replace(c.ToString(), ""));

            return newFileName;
        }

        /// <summary>
        /// For <paramref name="s"/> that has length bigger than <paramref name="limit"/>
        /// this function splits the <paramref name="s"/>, so the splitted <paramref name="s"/> parts are not bigger
        /// than the <paramref name="limit"/>
        /// </summary>
        /// <param name="s"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitLimit(this string s, int limit)
        {
            for (int i = 0; i < (int)Math.Ceiling(s.Length / (double)limit); i++)
            {
                if ((i + 1) * limit > s.Length)
                {
                    yield return s.Substring(i * limit, s.Length - i * limit);
                }
                else
                {
                    yield return s.Substring(i * limit, limit);
                }
            }
        }
        
        private static bool ValidateHexString(string input, char separator)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return false;
            }

            Regex hexStringPatternWithCommaDelimeter = new Regex(_hexStringPatternWithDelimeter.Replace("<replaceMe>", separator.ToString()));

            MatchCollection matchedElements = hexStringPatternWithCommaDelimeter.Matches(input);

            int matchedElementsOverallLength = 0;

            foreach (Match match in matchedElements)
            {
                matchedElementsOverallLength += match.Length;
            }

            return matchedElementsOverallLength == input.Length;
        }

        public static byte[] HexStringWithSeparatorToByteArray(string input, char separator)
        {
            return Array.ConvertAll(input.Replace("0x", "").Split(separator).RemoveEmptyElements(),
                                           s => byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
        }
    }
}