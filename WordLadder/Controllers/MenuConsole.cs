using System;
using System.Collections.Generic;
using System.IO;

namespace WordLadder
{
    public class MenuConsole
    {
        public ValidationHelper ValidationHelper;

        protected const string ResultTxtPath = @"C:\Users\Flavio Freire\source\repos\WordLadder\result.txt";
        protected bool StartWordValid { get; set; }
        protected bool EndWordValid { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }

        public MenuConsole(ValidationHelper validationHelper)
        {
            this.ValidationHelper = validationHelper;
            this.StartWordValid = false;
            this.EndWordValid = false;
            this.StartWord = null;
            this.EndWord = null;

        }

        public void Start()
        {
            Console.WriteLine("Word Ladder");
            Console.WriteLine("\n");

            #region Start Word
            while (!this.StartWordValid)
            {
                Console.WriteLine("Please Enter The Start Word :");
                this.StartWord = Console.ReadLine();

                if (this.ValidationHelper.ValidateWordExist(this.StartWord))
                {
                    if (this.ValidationHelper.ValidateWordLength(this.StartWord))
                    {
                        this.StartWordValid = true;
                        Console.Clear();
                        Console.WriteLine("Start Word - " + this.StartWord);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid length word!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid word!");
                }
            }
            #endregion

            #region End Word
            while (!this.EndWordValid)
            {
                Console.WriteLine("Please Enter The End Word :");
                this.EndWord = Console.ReadLine();
                if (this.ValidationHelper.ValidateWordExist(this.EndWord))
                {
                    if (this.ValidationHelper.ValidateWordLength(this.EndWord))
                    {
                        this.EndWordValid = true;
                        Console.Clear();
                        Console.WriteLine("Start Word - " + this.StartWord);
                        Console.WriteLine("End Word - " + this.EndWord);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid length word!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid word!");
                }
            }
            #endregion

            Console.Clear();
            Console.WriteLine("Start Word - " + this.StartWord);
            Console.WriteLine("End Word - " + this.EndWord);
        }

        public void End(List<List<string>> resultStrings)
        {
            Console.WriteLine("Word Ladder");
            Console.WriteLine("Start Word:" + this.StartWord);
            Console.WriteLine("End Word:" + this.EndWord);
            foreach (var item in resultStrings)
            {
                Console.WriteLine("Result " + (resultStrings.IndexOf(item) + 1) + ":");
                foreach (var word in item)
                {
                    if (item.IndexOf(word) != item.Count - 1)
                        Console.Write(word + " -> ");
                    else
                        Console.WriteLine(word);
                }
            }

            Console.WriteLine(@"Please see the result in: WordLadder\result.txt");
        }
    }
}
