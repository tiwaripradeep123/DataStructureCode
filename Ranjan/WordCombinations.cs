using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Ranjan
{
    /*
         Given an array of words, return the length of the longest phrase, containing only unique characters, 
        that you can form by combining the given words together. 
        Ex: Given the following words…
        words = ["the","dog","ran"], return 9 because you can combine all the words, i.e. "the dog ran" since all the characters in the phrase are unique.
        Ex: Given the following words…
        words = ["the","eagle","flew"], return 4 because "flew" is the longest phrase you can create without using duplicate characters.
     */
    public class WordCombinations
    {
        public static void Tests()
        {
            var obj = new WordCombinations();
            var input = new string[] { "the", "dog", "ran" };
            var actual = obj.WordCombinationsBitWise(input);
            var expected = 6;
            Console.WriteLine($"acutal = {actual}, expected = {expected}");


             input = new string[] { "the", "eagle", "flew" };
             actual = obj.WordCombinationsBitWise(input);
             expected = 0;
            Console.WriteLine($"acutal = {actual}, expected = {expected}");
        }

        public int WordCombinationsBitWise(string[] words)
        {
            int length = words.Length;
            var masks = new int[length];
            var lengths = new int[length];
            for (int i = 0; i < length; i++)
            {
                var word = words[i];
                int mask = 0;
                for (int j = 0; j < word.Length; j++)
                {
                    mask |= 1 << GetNumber(word[j]);
                }
                masks[i] = mask;
                lengths[i] = word.Length;
            }

            int max = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if ((masks[i] & masks[j]) == 0)
                    {
                        max = Math.Max(max, (lengths[j] + lengths[j]));
                    }
                }
            }

            return max;
        }

        int GetNumber(char c)
        {
            return c - 'a';
        }
    }
}
