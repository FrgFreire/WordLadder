using System;
using Xunit;
using WordLadder;
using System.Collections.Generic;

namespace TestWordLadder
{
    public class WordLadderFindShortestPathsTest
    {
        private const string WordsSourcePath = @"..\..\..\..\WordLadder\words-english.txt";

        [Theory]
        [InlineData("full","more", WordsSourcePath)]
        public void Find_Shortest_Paths_With_Single_Result(string stratWord, string endWord, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            var result = FinderHelper.FindShortestPaths(stratWord, endWord, wordsSource.Words);

            Assert.True(result.Count == 1);
        }

        [Theory]
        [InlineData("fill", "more", WordsSourcePath)]
        public void Find_Shortest_Paths_With_Multiple_Results(string stratWord, string endWord, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            var result = FinderHelper.FindShortestPaths(stratWord, endWord, wordsSource.Words);

            Assert.True(result.Count > 1);
        }

    }
}
