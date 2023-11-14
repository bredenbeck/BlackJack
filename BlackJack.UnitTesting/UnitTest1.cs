namespace BlackJack.UnitTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region PlayingCard

        [TestCase(CardValue.Ace, 11)]
        [TestCase(CardValue.Five, 5)]
        [TestCase(CardValue.Jack, 10)]
        [TestCase(CardValue.Queen, 10)]
        [TestCase(CardValue.King, 10)]
        public void CalculateNumeralValue_ConstructingPlayingCard_PlayingCardWithExpectedNumeralValue(CardValue cardValue, int expected)
        {
            PlayingCard playingCard = new PlayingCard(CardColor.Clubs, cardValue, true);

            int actual = playingCard.NumeralValue;

            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion
    }
}