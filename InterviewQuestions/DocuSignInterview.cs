using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    // ✨ THE CODING EXERCISE ✨
    //
    // Implement a proximity search method.
    //
    // Given text as input, two keywords and a numeric range / window, return the number of times
    // both keyword 1 and keyword 2 are found within the given range throughout the text, or 0
    // if your search is not successful. The keywords themselves are considered to be part of the range. 
    // This makes 2 the minimum valid range for keyword proximity.
    //
    // For simplicity, assume all words are separated with a whitespace.
    //
    // input
    //
    //     text(text)    : The early bird gets the worm
    //     keyword1(text): bird
    //     keyword2(text): worm
    //     range(number) : 4
    //
    // output
    //
    //     result(number): 1
    /*
     1. split input into words 
     2. iterate till the end 
       1. tail = 0; 
       2. start processing set IsFirstWordFound/IsSecondWordFound = true if it matches- increment the result count 
       3. once i = range
       4. elimate tail word 
       5. getnew word  

    */
    using System;
    using System.Collections.Generic;

    public class ProximitySearch
    {
        public static int Search(string text, string keyword1, string keyword2, int range)
        {
            if (text == null || text.Length == 0)
            {
                return -1;
            }

            int count = 0;
            var firstWordIndex = new List<int>();
            var secondWordIndex = new List<int>();
            text = text.ToLower();
            keyword1 = keyword1.ToLower();
            keyword2 = keyword2.ToLower();
            var words = text.Split(" ");
            for (int index = 0; index < words.Length; index++)
            {
                var thisword = words[index];
                var isOneOfTheWords = false;
                if (thisword == keyword1)
                {
                    isOneOfTheWords = true;
                    firstWordIndex.Add(index);
                }
                if (thisword == keyword2)
                {
                    isOneOfTheWords = true;
                    secondWordIndex.Add(index);
                }

                if (firstWordIndex.Count > 0 && secondWordIndex.Count > 0 && isOneOfTheWords)
                {
                    int thisCount = (thisword == keyword1 ? secondWordIndex.Count : firstWordIndex.Count);
                    count = count + thisCount;
                    Console.WriteLine($"{thisCount} - {count} , {thisword}, {firstWordIndex.Count}, {secondWordIndex.Count}");
                }
                var tail = index - (range - 1);
                Console.WriteLine($"");
                if (tail >= 0)
                {
                    if (firstWordIndex.Contains(tail))
                    {
                        firstWordIndex.Remove(tail);
                    }
                    if (secondWordIndex.Contains(tail))
                    {
                        secondWordIndex.Remove(tail);
                    }
                }
            }

            // Implement this method.  3 -(4-1) => 3-3 =0,  6-(4-1) => 3 
            return count;
        }

        /* range
        range
         bird bird worm worm
        // *         *          (first bird, first worm)
        // *              *     (first bird, second worm)
        //      *    *          (second bird, first worm)
              *         *     (second bird, second worm)
        */
        public static void Maiqweqwn()
        {
            // Test cases:
            // the early bird gets the worm a happy bird indeed
            Test("the early bird gets the worm", "bird", "worm", 4, 1); // basic search returns 1
            Test("the early bird gets the worm", "bird", "worm", 1, 0); // range < 2 returns 0
            Test("the early bird gets the worm a happy bird indeed", "bird", "worm", 4, 2); // matches can share words
            Test("the early bird bird worm worm gets the worm.", "bird", "worm", 4, 4); // matches can overlap but must only be counted once
            Test("the early bird gets the worm", "worm", "bird", 4, 1); // the order of the keywords doesn't matter
            Test("the early worm gets the bird", "bird", "worm", 4, 1); // ditto (i.e. keyword2 can come before keyword1)
            Test("the early bird gets the worm", "bird", "worm", 3, 0); // out of range returns 0
            Test("the early bird gets the worm", "bird", "missing", 4, 0); // keyword not in text returns 0
            Test("The early bird gets the worm", "The", "bird", 3, 2); // capitalization doesn't matter
        }

        // test method please ignore
        // (All this does is run the above test cases. ☝🏼)
        public static void Test(string text, string keyword1, string keyword2, int range, int expectedReturnValue)
        {
            int actual = Search(text, keyword1, keyword2, range);
            string outcome = actual == expectedReturnValue ? "Pass ✅" : "Fail ❌";

            Console.WriteLine($"{outcome}  text: \"{text}\", keyword1: \"{keyword1}\", keyword2: \"{keyword2}\", range: {range}, expected: {expectedReturnValue}, actual: {actual}");
        }
    }
}