using System.Collections.Generic;


namespace WordLadder
{
    public class ValidationHelper
    {
        protected const int VALID_WORD_LENGTH = 4;
        protected List<string> Words;
        public ValidationHelper(List<string> words)
        {
            this.Words = words;
        }

        public bool ValidateWordExist(string word)
        {
            if (Words.Exists(w => w.Equals(word)))
                return true;
            return false;
        }

        public bool ValidateWordLength(string word)
        {
            if (word.Length == VALID_WORD_LENGTH)
                return true;
            return false;
        }

        public bool ValidateWord(string word)
        {
            if ((word.Length == VALID_WORD_LENGTH) && (Words.Exists(w => w.Equals(word))))
                return true;
            return false;
        }
    }
}
