using Diversion;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [Test]
        public void ReturnMatchingChains(int digitsInChain)
        {
            //given
            BinaryChainAnaliser analiser = new BinaryChainAnaliser();
            string binaryNumber = "101001000010011100";

            //when, then
            int result = analiser.NumberOfMatchingChains(binaryNumber, digitsInChain);

            switch (digitsInChain)
            {
                case 2:
                    Assert.IsTrue(result == 8);
                    break;

                case 3:
                    Assert.IsTrue(result == 5);
                    break;

                case 4:
                    Assert.IsTrue(result == 3);
                    break;

                case 5:
                    Assert.IsTrue(result == 2);
                    break;
            }

        }
    }
}