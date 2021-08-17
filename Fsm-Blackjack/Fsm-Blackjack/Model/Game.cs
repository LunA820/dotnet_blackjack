using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fsm_Blackjack.Model
{
    public class Game
    {
        public class Board
        {
            public int s { get; set; }
            public List<int> pCards { get; set; }
            public List<int> dCards { get; set; }
        }


        private Player player;
        private Player dealer;
        private int state;

        public Game()
        {
            player = new Player();
            dealer = new Player();
            state = 0;
        }

        public bool start() {
            if (state != 0) { return false; }
            state = 1;
            player.reset();
            dealer.reset();

            player.hit();player.hit();
            dealer.hit();dealer.hit();

            if (dealer.getBlackjack()) { state = 3; }
            else if (player.getBlackjack()) { state = 2; }
            return true;
        }

        public bool hit() {
            if (state != 1) { return false; }
            player.hit();
            if (player.getBlackjack()) { state = 2; }
            else if (player.getBust()) { state = 3; }
            return true;
        }

        public bool stand() {
            if (state != 1) { return false; }
            while (dealer.getPoints() < player.getPoints()){
                dealer.hit();
            }
            if (dealer.getBlackjack()) { state = 3; }
            else if (dealer.getBust()) { state = 2; }
            return true;
        }

        public bool rematch() {
            if (state < 2) { return false; }
            state = 0;
            player.reset();
            dealer.reset();
            return true;
        }

        public string getBoard()
        {
            var b = new Board()
            {
                s = state,
                dCards = dealer.getCards(),
                pCards = player.getCards()
            };

            string s = JsonConvert.SerializeObject(b);
            return s;
        }
    }
}
