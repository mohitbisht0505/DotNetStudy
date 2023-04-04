using Microsoft.AspNetCore.Mvc;
using web_API.Model;

namespace web_API.Controllers
{
    public class PlayerController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        ApplicationDbContext db;
        public PlayerController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        [Route(template:"AddPlayer")]
        public IActionResult AddPlayer(IplPlayer players)
        {
            db.iplPlayer.Add(players);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route(template: "ViewPlayer")]

        public IActionResult ViewPlayer()
        {
           var lstPlayer = db.iplPlayer.ToList();
            
                return Ok(lstPlayer);
        }
    }
}
