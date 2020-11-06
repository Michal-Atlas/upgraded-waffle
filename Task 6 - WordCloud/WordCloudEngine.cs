using System;
using System.Collections.Generic;

namespace WordCloud
{
    public class WordCloudEngine
    {
        public IDictionary<string, int> Words { get; private set; }

        public WordCloudEngine(string sentence)
        {
            Words = new Dictionary<string, int>();
            CreateCloud(sentence);
        }

        private string FirstUpper(string word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1);
        }
        private void CreateCloud(string sentence)
        {
            var sep = sentence.Split(new []{",",".", "?", "!"," -", "- "," ", "\u2026", "...", "\r\n", "\n"}, StringSplitOptions.None);
            foreach (var word in sep)
            {
                if(word.Length > 0)
                {
                    if (word == word.ToLower()&&Words.ContainsKey(FirstUpper(word)))
                    {
                        var cache = Words[FirstUpper(word)];
                        Words.Remove(FirstUpper(word));
                        Words[word] = cache+1;
                        
                    }else if (word != word.ToLower() && Words.ContainsKey(word.ToLower()))
                    {
                        Words[word.ToLower()]++;
                    }
                    else
                    {
                        if (Words.ContainsKey(word))
                        {
                            Words[word]++;
                        }else{Words.Add(word, 1);}
                    }
                }
            }
        }
    }
}
