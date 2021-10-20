using System.Collections.Generic;
using System.Text;

namespace WordLadder
{
    public static class FinderHelper
    {
        public static List<List<string>> FindShortestPaths(string beginWord, string endWord, List<string> wordList)
        {

            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
            AddWordToGraph(beginWord, graph);
            foreach (var word in wordList)
                AddWordToGraph(word, graph);

            //Queue For BFS
            Queue<string> queue = new Queue<string>();

            //Dictionary to store shortest paths to a word
            Dictionary<string, List<List<string>>> paths = new Dictionary<string, List<List<string>>>();

            queue.Enqueue(beginWord);
            paths[beginWord] = new List<List<string>>() { new List<string>() { beginWord } };

            HashSet<string> visited = new HashSet<string>();

            while (queue.Count > 0)
            {

                var stopWord = queue.Dequeue();

                if (!stopWord.Equals(endWord))
                {
                    if (!visited.Contains(stopWord))
                    {
                        visited.Add(stopWord);

                        //Transform word to intermidiate words and find matches
                        for (int i = 0; i < stopWord.Length; i++)
                        {

                            StringBuilder sb = new StringBuilder(stopWord);
                            sb[i] = '*';
                            var transform = sb.ToString();

                            if (graph.ContainsKey(transform))
                            {

                                //Iterating all adj words
                                foreach (var word in graph[transform])
                                {
                                    if (!visited.Contains(word))
                                    {
                                        //fetch all paths leads current word to generate paths to adj/child node 
                                        foreach (var path in paths[stopWord])
                                        {

                                            var newPath = new List<string>(path);
                                            newPath.Add(word);

                                            if (!paths.ContainsKey(word))
                                                paths[word] = new List<List<string>>() { newPath };
                                            else if (paths[word][0].Count >= newPath.Count)// we are interested in shortest paths only
                                                paths[word].Add(newPath);
                                        }
                                        queue.Enqueue(word);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                else
                {
                    //we can terminate loop once we reached the endWord as all paths leads here already visited in previous level
                    return paths[endWord];
                }

            }

            return new List<List<string>>();

        }

        //For example word full can be written as *ull,f*ll,fu*l,ful*. 
        //This method genereates a map from each intermediate word to possible words from our wordlist
        private static void AddWordToGraph(string word, Dictionary<string, HashSet<string>> graph)
        {

            for (int i = 0; i < word.Length; i++)
            {

                StringBuilder sb = new StringBuilder(word);
                sb[i] = '*';

                if (graph.ContainsKey(sb.ToString()))
                    graph[sb.ToString()].Add(word);
                else
                {
                    var set = new HashSet<string>();
                    set.Add(word);
                    graph[sb.ToString()] = set;
                }

            }

        }
    }
}
