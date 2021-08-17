using Microsoft.AspNetCore.Mvc;
using Fsm_Blackjack.Model;


namespace Fsm_Blackjack.Controllers
{
    

    [Route("api/[controller]")]
    public class BlackjackController : Controller
    {
        /*
            A Controller is created for each request.
            If we want to modify persistent data,
            we need a static property.
         */
        //private static Player p = new Player();
        private static Game g = new Game();

        public BlackjackController(){}


        [HttpGet]
        public string Get() { return g.getBoard(); }

        [HttpGet("start")]
        public string Start()
        {
            if (!g.start()) { return "wrongState"; }
            return g.getBoard();
        }

        [HttpGet("hit")]
        public string Hit() {
            if (!g.hit()) { return "wrongState"; }
            return g.getBoard();
        }

        [HttpGet("stand")]
        public string Stand()
        {
            if (!g.stand()) { return "wrongState"; }
            return g.getBoard();
        }

        [HttpGet("rematch")]
        public string Rematch()
        {
            if (!g.rematch()) { return "wrongState"; }
            return g.getBoard();
        }

    }
}
