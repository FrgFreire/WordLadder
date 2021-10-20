using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadder
{
    public class WordsSource
    {
        public string SourcePath;
        protected string[] Lines;
        public List<string> Words { get; set; }

        public WordsSource(string sourcePath)
        {
            this.SourcePath = sourcePath;
            this.Lines = System.IO.File.ReadAllLines(sourcePath);
            this.Words = new List<string>(this.Lines);
        }
    }
}
