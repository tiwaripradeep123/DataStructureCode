using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{

    public class DocuSignScreening
    {
        public TrieEntry Root = new TrieEntry('/');
        static string[] dictionary = new string[] { "apple", "air", "airline", "airplane", "bee", "beetle", "zoo", "cat" };
        //A,a – apple, air, airline, airplane   
        //Ap – apple   
        //Air – air, airline, airplane   
        //Airp – airplane   
        //B – bee, beetle  
        //Be – bee, beetle   
        //Bee – bee, beetle   
        //Beet – beetle     public 
        // input -> a-z, 0-9 => 
        //  ""->['a',['p', 'i'],'b'['e'], 'z'['o'['o']]]
        /* a -> [] ->ap
        Build the data 
        -> loop dictionary -> 0- n-1
          -> for each 
             root = trie root;  
              iterate through each char 
                for each char 
                  (!tries[c])
                  {
                    add this char as child 
                       root
                  }
        class Entry
        {
          char 
          List<char, entry> 
        }
        dictionary<char, list<dictionary<char, >>>

        */
        static void TrieMain()
        {
            var testObj = new DocuSignScreening();
            testObj.BuildAutoComplete();
            Console.WriteLine(string.Join(",", testObj.GetAutoComplete("be").ToArray()));
        }

        public void BuildAutoComplete()
        {
            foreach (var word in dictionary)
            {
                var root = Root;
                foreach (char c in word)
                {
                    if (root.Children.Any(x => x.Key == c))
                    {
                        var newRoot = new TrieEntry(c);
                        root.Children.Add(newRoot);
                        root = newRoot;
                    }
                    else
                    {
                        root = root.Children[c];
                    }
                }
                root.Children.Add(new TrieEntry('/'));
            }
        }

        private List<string> GetAutoComplete(string predicate)
        {
            var root = Root;
            foreach (var c in predicate)
            {
                root = root.Children.Find(e => e.Key == c);
                if (root == null)
                {
                    root = null;
                    break;
                }
            }
            var result = FindAllSuggestions(predicate, root);
            return new List<string>() { "bee", "beetle" };
        }

        public List<string> FindAllSuggestions(string prefix, TrieEntry root)
        {
            if (root == null)
            {
                return new List<string>();
            }
            var result = new List<string>();
            foreach (var child in root.Children)
            {
                ConstructAddWordsRecursieve(prefix + root.Key, child, result);
            }

            return result;
        }

        private void ConstructAddWordsRecursieve(string prefix, TrieEntry child, List<string> result)
        {
            //if (root == null)
            //{
            //    return new List<string>();
            //}
            //var result = new List<string>();
            //foreach (var child in root.Children)
            //{
            //    ConstructAddWordsRecursieve(prefix + root.Key, child, result);
            //}

            //return result;

            //if (child.Key == '/')
            //{
            //    result.Add(prefix);
            //}
            //else
            //{
            //    ConstructAddWordsRecursieve(prefix + child.Key, )
            //}
        }

        public class TrieEntry
        {
            public char Key;
            public List<TrieEntry> Children = new List<TrieEntry>();

            public TrieEntry(char c)
            {
                Key = c;
            }
        }
    }
}