using System;
using System.Collections.Generic;
using System.Text;

namespace anagrams
{
    public class AnagramEngine
    {
        private AnagramCreator _anagramCreator;

        public AnagramEngine()
        {
            _anagramCreator = new AnagramCreator();
        }

        public void StartApp(List<string> userValues)
        {
            foreach (var word in userValues)
            {
                _anagramCreator.GenerateAnagramFromGivenWord(word);
            }
        }  
    }
}
