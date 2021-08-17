using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;


namespace Fsm_Blackjack.Model
{
    public class Player
    {
        private List<int> cards;
        private bool bust;
        private bool blackjack;


        public Player()
        {
            cards = new List<int>();
            bust = false;
            blackjack = false;
        }

        // Getters
        public List<int> getCards() { return cards; }
        public bool getBust() { return bust; }
        public bool getBlackjack() { return blackjack; }

        // Player draw random card
        public void hit() {
            Random rnd = new Random();
            cards.Add(rnd.Next(1, 53));
            bust = (getPoints() > 21);
            blackjack = (getPoints() == 21);
        }

        // Reset player
        public void reset(){
            cards.Clear();
            bust = false;
            blackjack = false;
        }

        // Calculate card worth for player
        public int getPoints()
        {
            int pt = 0;
            bool ace = false;

            foreach (int c in cards)
            {
                if (c % 10 == 1) { ace = true; }
                if (c < 41) { pt += c % 10; }
                else { pt += 10; }
            }
            if (ace && (pt + 10 <= 21)) { pt += 10; }

            return pt;
        }
    }
}
