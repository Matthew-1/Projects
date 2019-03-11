using anagrams;
using NUnit.Framework;

namespace Tests
{
    public class CreatingAnagram
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AnagramFromGivenWord()
        {
            //given
            AnagramCreator anagram = new AnagramCreator();
            string wordToFindAnagram = "pictures";
            string[] words = { "crepitus", "cuprites", "pictures", "piecrust","milk" };

            //when,then
            anagram.GenerateAnagramFromGivenWord(wordToFindAnagram, words);

            Assert.AreEqual("crepitus", anagram.GetListOfAnagrams()[0]);
            Assert.AreEqual("cuprites", anagram.GetListOfAnagrams()[1]);
            Assert.AreEqual("piecrust", anagram.GetListOfAnagrams()[2]);
            Assert.IsTrue(anagram.GetListOfAnagrams().Count == 3);

        }

        [TestCase("picture")]
        [TestCase("bark")]
        [TestCase("milky")]
        [TestCase("cats")]
        [Test]
        public void AnagramNotFound(string chosenWord)
        {
            //given
            AnagramCreator anagram = new AnagramCreator();
            string wordToFindAnagram = chosenWord;
            string[] words = { "cat", "milk","pictures" };

            //when,then
            anagram.GenerateAnagramFromGivenWord(wordToFindAnagram, words);

            Assert.IsTrue(anagram.GetListOfAnagrams().Count == 0);

        }
    }
}