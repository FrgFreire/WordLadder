using System;
using System.Collections.Generic;
using System.Text;
using WordLadder;
using Xunit;

namespace TestWordLadder
{
    public class WordLadderResultWriterTest
    {
        private const string WordsSourcePath = @"..\..\..\..\WordLadder\words-english.txt";
        private const string ResultPath = @"..\..\..\..\WordLadder\result.txt";

        [Theory]
        [InlineData("fill", "more", WordsSourcePath, ResultPath)]
        public void WriteToTxt(string stratWord, string endWord, string wordsSourcePath, string resultPath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            var result = FinderHelper.FindShortestPaths(stratWord, endWord, wordsSource.Words);
            var success = ResultWriter.WriteToTxt(resultPath, stratWord, endWord, result);

            Assert.True(success);
        }
    }
}
