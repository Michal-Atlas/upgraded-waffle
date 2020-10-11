using System;

namespace FlippingPoint
{
    public class Flipper
    {
        public static int FindFlippingPoint(string[] words)
        {
            int i = 1;
            while (i < words.Length && String.Compare(words[i-1], words[i], StringComparison.Ordinal) < 0)
            {
                i++;
            }


            return i;
        }
    }
}