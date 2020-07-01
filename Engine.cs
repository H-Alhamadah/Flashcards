using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Engine
    {
        public static List<Deck> decksList = new List<Deck>();
        public static Deck newDeck = new Deck("");

        public Engine()
        {
            try
            {
                StreamReader reader = new StreamReader($"{Environment.CurrentDirectory}{@"\Data.txt"}");
                String line = reader.ReadLine();
                while (line != null)
                {
                    if (line.StartsWith("Deck Name:"))
                    {
                        Deck deck = new Deck(line.Substring("Deck Name:".Length));
                        decksList.Add(deck);
                        decksList.Last().addCard(reader.ReadLine().Substring("Question:".Length), reader.ReadLine().Substring("Answer:".Length));
                    }
                    else
                    {
                        decksList.Last().addCard(line.Substring("Question:".Length), reader.ReadLine().Substring("Answer:".Length));
                    }
                line = reader.ReadLine();
                }

                reader.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void saveData()
        {
            StreamWriter writer = new StreamWriter($"{Environment.CurrentDirectory}{@"\Data.txt"}");
            for(int i=0; i<decksList.Count; i++)
            {
                writer.WriteLine("Deck Name: " + decksList[i].Name);
                for(int j=0; j<decksList[i].deck.Count; j++)
                {
                    writer.WriteLine("Question: "+decksList[i].deck[j].question);
                    writer.WriteLine("Answer: "+decksList[i].deck[j].answer);

                }

            }
            writer.Close();
        }

        public Boolean uniqueDeckName(String name)
        {
            for (int i = 0; i < decksList.Count; i++)
            {
                if (name == decksList[i].Name)
                {
                    return false;
                }
            }
            return true;
        }

        public Card[] generateOrderedArray(Deck d)
        {

            Card[] deckArray = new Card[d.deck.Count];
            int i = 0;
            foreach (Card c in d.deck)
            {
                deckArray[i++] = c;
            }
            return deckArray;
        }

        public Card[] generateShuffledArray(Deck d)
        {
            Card[] deckArray = generateOrderedArray(d);

            Random rand = new Random();

            for (int t = 0; t < deckArray.Length - 1; t++)
            {
                int j = rand.Next(t, deckArray.Length);
                Card temp = deckArray[t];
                deckArray[t] = deckArray[j];
                deckArray[j] = temp;
            }
            return deckArray;
        }
    }
}
