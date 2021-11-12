using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    public class SimilarSentence
    {
        public static void Tests()
        {
            var sentence1 = new string[] { "this", "summer", "thomas", "get", "actually", "really", "rich", "and", "own", "unique", "extremely", "great", "and", "wonderful", "truck", "every", "morning", "he", "drives", "unique", "nice", "truck", "around", "some", "good", "city", "to", "have", "the", "really", "fine", "fruits", "as", "his", "dinner", "but", "he", "only", "drink", "an", "few", "wonderful", "fruits", "as", "unique", "breakfast", "he", "wants", "to", "drink", "an", "one", "and", "extremely", "healthy", "life" };

            var sentence2 = new string[] { "this", "summer", "thomas", "get", "actually", "actually", "rich", "and", "have", "an", "really", "fine", "and", "great", "car", "every", "morning", "he", "drives", "some", "wonderful", "truck", "around", "some", "wonderful", "city", "to", "take", "some", "actually", "nice", "brunch", "as", "his", "food", "but", "he", "only", "eat", "an", "few", "excellent", "food", "as", "an", "fruits", "he", "wants", "to", "entertain", "an", "one", "and", "actually", "healthy", "life" };

            IList<IList<string>> pairs = new List<IList<string>>() { new List<string>() { "good", "nice" }, new List<string>() { "good", "excellent" }, new List<string>() { "good", "well" }, new List<string>() { "good", "great" }, new List<string>() { "fine", "nice" }, new List<string>() { "fine", "excellent" }, new List<string>() { "fine", "well" }, new List<string>() { "fine", "great" }, new List<string>() { "wonderful", "nice" }, new List<string>() { "wonderful", "excellent" }, new List<string>() { "wonderful", "well" }, new List<string>() { "wonderful", "great" }, new List<string>() { "extraordinary", "nice" }, new List<string>() { "extraordinary", "excellent" }, new List<string>() { "extraordinary", "well" }, new List<string>() { "extraordinary", "great" }, new List<string>() { "one", "a" }, new List<string>() { "one", "an" }, new List<string>() { "one", "unique" }, new List<string>() { "one", "any" }, new List<string>() { "single", "a" }, new List<string>() { "single", "an" }, new List<string>() { "single", "unique" }, new List<string>() { "single", "any" }, new List<string>() { "the", "a" }, new List<string>() { "the", "an" }, new List<string>() { "the", "unique" }, new List<string>() { "the", "any" }, new List<string>() { "some", "a" }, new List<string>() { "some", "an" }, new List<string>() { "some", "unique" }, new List<string>() { "some", "any" }, new List<string>() { "car", "vehicle" }, new List<string>() { "car", "automobile" }, new List<string>() { "car", "truck" }, new List<string>() { "auto", "vehicle" }, new List<string>() { "auto", "automobile" }, new List<string>() { "auto", "truck" }, new List<string>() { "wagon", "vehicle" }, new List<string>() { "wagon", "automobile" }, new List<string>() { "wagon", "truck" }, new List<string>() { "have", "take" }, new List<string>() { "have", "drink" }, new List<string>() { "eat", "take" }, new List<string>() { "eat", "drink" }, new List<string>() { "entertain", "take" }, new List<string>() { "entertain", "drink" }, new List<string>() { "meal", "lunch" }, new List<string>() { "meal", "dinner" }, new List<string>() { "meal", "breakfast" }, new List<string>() { "meal", "fruits" }, new List<string>() { "super", "lunch" }, new List<string>() { "super", "dinner" }, new List<string>() { "super", "breakfast" }, new List<string>() { "super", "fruits" }, new List<string>() { "food", "lunch" }, new List<string>() { "food", "dinner" }, new List<string>() { "food", "breakfast" }, new List<string>() { "food", "fruits" }, new List<string>() { "brunch", "lunch" }, new List<string>() { "brunch", "dinner" }, new List<string>() { "brunch", "breakfast" }, new List<string>() { "brunch", "fruits" }, new List<string>() { "own", "have" }, new List<string>() { "own", "possess" }, new List<string>() { "keep", "have" }, new List<string>() { "keep", "possess" }, new List<string>() { "very", "super" }, new List<string>() { "very", "actually" }, new List<string>() { "really", "super" }, new List<string>() { "really", "actually" }, new List<string>() { "extremely", "super" }, new List<string>() { "extremely", "actually" } };

            var obj = new SimilarSentence();
            obj.AreSentencesSimilar(sentence1, sentence2, pairs);
        }
        public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
        {
            if (sentence1.Length != sentence2.Length)
            {
                return false;
            }

            var sentence = new List<string>();
            for (int i = 0; i < sentence2.Length; i++)
            {
                sentence.Add(sentence2[i]);
            }

            var graph = CreateEdgeGraph(similarPairs);
            Console.WriteLine("Printing graph");
            foreach (var item in graph)
            {
                Console.WriteLine(item.Key + " -> " + string.Join(" , ", item.Value));
            }
            Console.WriteLine("End - Printing graph");

            for (int i = 0; i < sentence1.Length; i++)
            {
                var word = sentence1[i];
                if (sentence.Contains(word))
                {
                    sentence.Remove(word);
                }
                else if (graph.ContainsKey(word))
                {
                    bool found = false;
                    foreach (var s in graph[word])
                    {
                        if (sentence.Contains(s))
                        {
                            found = true;
                            sentence.Remove(s);
                            break;
                        }
                    }
                    if (!found)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            return sentence.Count == 0;
        }

        public Dictionary<string, HashSet<string>> CreateEdgeGraph(IList<IList<string>> pairs)
        {
            var graph = new Dictionary<string, HashSet<string>>();
            foreach (var item in pairs)
            {
                if (!graph.ContainsKey(item[0]))
                {
                    graph.Add(item[0], new HashSet<string>());
                }
                if (!graph.ContainsKey(item[1]))
                {
                    graph.Add(item[1], new HashSet<string>());
                }

                graph[item[0]].Add(item[1]);
                graph[item[1]].Add(item[0]);
            }

            return graph;
        }
    }
}
