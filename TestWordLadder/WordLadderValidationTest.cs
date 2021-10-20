using System;
using System.Collections.Generic;
using System.Text;
using WordLadder;
using Xunit;

namespace TestWordLadder
{
    public class WordLadderValidationTest
    {
        private const string WordsSourcePath = @"..\..\..\..\WordLadder\words-english.txt";

        [Theory]
        [InlineData("more", WordsSourcePath)]
        public void Validate_If_Input_Word_Exist(string word, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool WordExist = validationHelper.ValidateWordExist(word);

            Assert.True(WordExist);
        }

        [Theory]
        [InlineData("asds", WordsSourcePath)]
        public void Validate_If_Input_Word_Not_Exist(string word, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool WordExist = validationHelper.ValidateWordExist(word);

            Assert.True(!WordExist);
        }
        [Theory]
        [InlineData("fill", WordsSourcePath)]
        public void Validate_The_Correct_Input_Word_Length(string word, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool IsWordLengthValid = validationHelper.ValidateWordLength(word);

            Assert.True(IsWordLengthValid);
        }

        [Theory]
        [InlineData("stuff", WordsSourcePath)]
        public void Validate_The_Wrong_Input_Word_Length(string word, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool IsWordLengthValid = validationHelper.ValidateWordLength(word);

            Assert.True(!IsWordLengthValid);
        }

        [Theory]
        [InlineData("more", WordsSourcePath)]
        public void Check_If_Word_Is_Valid(string word, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool IsWordValid = validationHelper.ValidateWord(word);

            Assert.True(IsWordValid);
        }

        [Theory]
        [InlineData("stuff", WordsSourcePath)]
        public void Check_If_Word_Is_Not_Valid(string word, string wordsSourcePath)
        {
            WordsSource wordsSource = new WordLadder.WordsSource(wordsSourcePath);
            ValidationHelper validationHelper = new WordLadder.ValidationHelper(wordsSource.Words);
            bool IsWordValid = validationHelper.ValidateWord(word);

            Assert.True(!IsWordValid);
        }
    }
}
