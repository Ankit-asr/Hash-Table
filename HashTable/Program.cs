using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            ShowFrequency(sentence);
        }
        /// <summary>
        /// show frequency of sentence
        /// </summary>
        /// <param name="sentence"></param>
        public static void ShowFrequency(string sentence)
        {
            bool checkFirst = true;
            string[] wordList = sentence.Split(" ");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(wordList.Length);
            foreach (string word in wordList)
            {
                if (checkFirst)
                {
                    hash.Add(word, "1");
                    checkFirst = false;
                    if (word.Equals("avoidable"))
                    {
                        hash.Remove(word);
                        checkFirst = true;
                    }
                }
                else
                {
                    if (hash.Get(word) != null)
                    {
                        int count = Convert.ToInt16(hash.Get(word));
                        count++;
                        hash.Remove(word);
                        hash.Add(word, count.ToString());
                    }
                    else
                    {
                        hash.Add(word, "1");
                    }
                    if (word.Equals("avoidable"))
                    {
                        hash.Remove(word);
                    }
                }
            }
            foreach (string key in wordList)
            {
                if (key != "avoidable")
                    Console.WriteLine(key + " Value is :" + hash.Get(key));
            }
        }
    }
}
