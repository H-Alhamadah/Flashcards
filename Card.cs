using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Card
    {
        public string question;
        public string answer;

        public Card(string Q, string A)
        {
            this.question = Q;
            this.answer = A;
        }
    }
}
