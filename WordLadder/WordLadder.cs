using System.Collections.Generic;

namespace WordLadder
{
    class WordLadder
    {
        static void Main(string[] args)
        {
            string wordSourcePath = @"..\..\..\..\WordLadder\words-english.txt";
            string resultPath = @"..\..\..\..\WordLadder\result.txt";

            WordsSource wordsSource = new WordsSource(wordSourcePath);
            ValidationHelper validationHelper = new ValidationHelper(wordsSource.Words);
            MenuConsole menu = new MenuConsole(validationHelper);

            menu.Start();

            List<List<string>> resultStrings = new List<List<string>>();

            resultStrings = FinderHelper.FindShortestPaths(menu.StartWord, menu.EndWord, wordsSource.Words);


            ResultWriter.WriteToTxt(resultPath, menu.StartWord, menu.EndWord, resultStrings);
            
            menu.End(resultStrings);
        }

    }
}
