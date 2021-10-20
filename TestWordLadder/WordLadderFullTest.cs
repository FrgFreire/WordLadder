using System;
using System.Collections.Generic;
using System.Text;
using WordLadder;
using Xunit;

namespace TestWordLadder
{
    public class WordLadderFullTest
    {
        private const string WordsSourcePath = @"..\..\..\..\WordLadder\words-english.txt";
        private const string ResultPath = @"..\..\..\..\WordLadder\result.txt";

        [Theory]
        [InlineData("fill", "more", WordsSourcePath, ResultPath)]
        public void FullTest(string stratWord, string endWord, string wordsSourcePath, string resultPath)
        {
            bool success = false;
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool startWordValid = validationHelper.ValidateWord(stratWord);
            bool endWordValid = validationHelper.ValidateWord(endWord);
            List<List<string>> result = new List<List<string>>();

            if (startWordValid && endWordValid)
            {
                result = FinderHelper.FindShortestPaths(stratWord, endWord, wordsSource.Words);
                success = ResultWriter.WriteToTxt(resultPath, stratWord, endWord, result);
            }

            Assert.True(result.Count >= 1 && success);

        }
    }
}
