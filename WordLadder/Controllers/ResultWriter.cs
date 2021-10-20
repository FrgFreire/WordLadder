using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordLadder
{
    public static class ResultWriter
    {
        public static bool WriteToTxt(string resultPath, string startWord, string endWord, List<List<string>> resultStrings)
        {
            bool success = false;
            using (StreamWriter sw = File.AppendText(resultPath))
            {
                sw.WriteLine("Word Ladder");
                sw.WriteLine("Start Word:" + startWord);
                sw.WriteLine("End Word:" + endWord);

                foreach (var item in resultStrings)
                {
                    sw.WriteLine("Result " + (resultStrings.IndexOf(item) + 1) + ":");
                    foreach (var word in item)
                    {
                        if (item.IndexOf(word) != item.Count - 1)
                            sw.Write(word + " -> ");
                        else
                            sw.WriteLine(word);
                    }
                }
                success = true;
            }
            return success;
        }
    }
}
