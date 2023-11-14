using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class PlayingCardDeck
    {
        #region Properties
        public List<PlayingCard> Cards { get; set; }
        public bool CardsInDeck { get; private set; }
        #endregion


        #region Constructors
        public PlayingCardDeck()
        {
            Cards = new();
            AddCardsToDeck();
            Shuffle();

            CardsInDeck = true;
        }

        #endregion

        #region Methods

        private void AddCardsToDeck()
        {
            foreach (CardColor cardColor in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                {
                    Cards.Add(new PlayingCard(cardColor, cardValue, false));
                }
            }
        }

        private void CheckIfCardsInDeck()
        {
            CardsInDeck = (Cards.Count > 0) ? true : false;
        }

        public void Shuffle()
        {
            List<PlayingCard> unshuffledDeck = Cards;
            Cards = new();

            Random random = new Random();

            while (unshuffledDeck.Count > 0)
            {
                int randomCardIndex = random.Next(0, unshuffledDeck.Count);
                Cards.Add(unshuffledDeck[randomCardIndex]);

                unshuffledDeck.RemoveAt(randomCardIndex);
            }

            Console.WriteLine("The deck is shuffled.");
        }

        public PlayingCard DrawTopCard()
        {
            CheckIfCardsInDeck();
            
            if (!CardsInDeck)
            {
                Console.WriteLine("Deck is empty. Press any key to shuffle deck.");
                Console.ReadKey(true);
                AddCardsToDeck();
                Shuffle();
                Console.WriteLine();
            }

            PlayingCard drawnCard = Cards[0];
            Cards.RemoveAt(0);

            return drawnCard;
        }

        public void AddCardToBottomOfDeck(PlayingCard card)
        {
            Cards.Add(card);
        }

        #endregion

    }
}
