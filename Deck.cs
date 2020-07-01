using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Deck
    {
        public List<Card> deck = new List<Card>();
        public String Name = "";
        public Boolean isShuffled = false;

        public Deck(String deckName)
        {
            this.Name = deckName;
        }

        public void addCard(String question, String answer)
        {
            Card card = new Card(question, answer);
            deck.Add(card);
        }

        public void shuffle()
        {
            isShuffled = true;
        }

        public void order()
        {
            isShuffled = false;
        }

    }
}
