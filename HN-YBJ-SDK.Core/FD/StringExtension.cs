﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Util
{
    public static  class StringExtension
    {
        public static string ToBase64(this string text)
        {
            return ToBase64(text, Encoding.UTF8);
        }

        public static byte[] HexStringToHex(this string text)
        {
            var resultantArray = new byte[text.Length / 2];
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = System.Convert.ToByte(text.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }

        public static string ToBase64(this string text, Encoding encoding)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            byte[] textAsBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        public static bool TryParseBase64(this string text, out string decodedText)
        {
            return TryParseBase64(text, Encoding.UTF8, out decodedText);
        }

        public static bool TryParseBase64(this string text, Encoding encoding, out string decodedText)
        {
            if (string.IsNullOrEmpty(text))
            {
                decodedText = text;
                return false;
            }

            try
            {
                byte[] textAsBytes = Convert.FromBase64String(text);
                decodedText = encoding.GetString(textAsBytes);
                return true;
            }
            catch (Exception)
            {
                decodedText = null;
                return false;
            }
        }
    }
}
