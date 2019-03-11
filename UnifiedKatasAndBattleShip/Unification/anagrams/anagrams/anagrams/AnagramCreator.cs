using SharedTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace anagrams
{
    public class AnagramCreator
    {
        private List<string> _anagrams;
        private string _messageForUser;
        private char[] _chosenWordLetters;
        private char[] _wordFromDBLetters;
        private Displayer _displayer;

        public AnagramCreator()
        {
            _displayer = new Displayer();
        }

        public void GenerateAnagramFromGivenWord(string chosenWord, string[] wordsNotFromFile = null)
        {
             _anagrams = new List<string>();

            string[] wordsToCreateAnagram;

            if (wordsNotFromFile == null)
            {
                FileOperations getWordsArray = new FileOperations();
                string path = "wordlist.txt";
                wordsToCreateAnagram = getWordsArray.ReadFile(path);
            }
            else
            {
                wordsToCreateAnagram = wordsNotFromFile;
            }

            AnagramCreatorEngine(chosenWord, wordsToCreateAnagram);

        }

        private void AnagramCreatorEngine(string chosenWord, string[] wordsToCreateAnagram)
        {
            

            foreach (var wordFromDB in wordsToCreateAnagram)
            {
                if (chosenWord.Length == wordFromDB.Length && AnaliseWord(chosenWord, wordFromDB))
                    _anagrams.Add(wordFromDB);
            }

            bool anagramFound;

            ClearDuplicates(chosenWord);

            if (_anagrams.Count == 0)
            {
                anagramFound = false;
            }
            else
            {
                anagramFound = true;
            }

            IsAnagramFound(anagramFound);
        }

        private void ClearDuplicates(string chosenWord)
        {
            for (int i = 0; i < _anagrams.Count; i++)
            {
                if (_anagrams[i] == chosenWord)
                    _anagrams.RemoveAt(i);
            }
        }

        private void IsAnagramFound(bool anagramFound)
        {
            if(anagramFound)
            {
                foreach (var anagram in _anagrams)
                {
                    _messageForUser = $"{anagram}";
                    _displayer.ConfirmativeMsgForUser(_messageForUser); 
                }
            }
            else
            {
                _messageForUser = $"Anagram not found";
                _displayer.ErrorMsgForUser(_messageForUser);
            }
        }

        private bool AnaliseWord(string chosenWord, string wordsFromDB)
        {
            _chosenWordLetters = chosenWord.ToCharArray();
            _wordFromDBLetters = wordsFromDB.ToCharArray();

            int correctionCounter = 0;

            for (int i = 0; i < _chosenWordLetters.Length; i++)
            {
                for (int j = 0; j < _wordFromDBLetters.Length; j++)
                {

                    var predisposeToBeAnAnagram = CheckMatchingLettersInWords(_chosenWordLetters, _wordFromDBLetters, chosenWord, wordsFromDB, i, j);

                    if (predisposeToBeAnAnagram)
                    {
                        i = -1;
                        j = -1;
                        correctionCounter++;
                        break;
                    }

                }

            }

            if (correctionCounter == chosenWord.Length)
                return true;
            else
                return false;
        }

        private bool CheckMatchingLettersInWords(char[] wordChars, char[] wordsChars,
            string word, string words, int i, int j)
        {

            if (wordChars[i] == wordsChars[j])
            {
                char[] tmpWord = new string(_chosenWordLetters).Remove(i, 1).ToCharArray();
                char[] tmpWords = new string(_wordFromDBLetters).Remove(j, 1).ToCharArray();

                _chosenWordLetters = tmpWord;
                _wordFromDBLetters = tmpWords;

                return true;
            }

            return false;
        }

        public List<string> GetListOfAnagrams()
        {
            return _anagrams;
        }
    }
}
