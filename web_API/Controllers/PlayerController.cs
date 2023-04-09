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

        //Retrieve data or View data
        [HttpGet]
        [Route(template: "ViewPlayer")]

        public IActionResult ViewPlayer()
        {
            var lstPlayer = db.iplPlayer.ToList();

            return Ok(lstPlayer);
        }

        //Add new data
        [HttpPost]
        [Route(template:"AddPlayer")]
        public IActionResult AddPlayer(IplPlayer players)
        {
            db.iplPlayer.Add(players);
            db.SaveChanges();
            return Ok();
        }

        //Update Data
        [HttpPut]
        [Route(template:"UpdatePlayer")]

        public IActionResult UpdatePlayer(IplPlayer player)
        {
            var data = db.iplPlayer.FirstOrDefault(x => x.Id == player.Id);
            if (data != null)
            {
                data.Name = player.Name;
                data.TeamName = player.TeamName;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Delete data
        [HttpDelete]
        [Route("DeleteData")]
        
        public IActionResult DeleteData(Guid id)
        {
            IplPlayer player;
            var data = db.iplPlayer.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                db.iplPlayer.Remove(data);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        
        

    }
}
