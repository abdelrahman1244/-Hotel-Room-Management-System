using __Hotel_Room_Management_System.Data;
using __Hotel_Room_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace __Hotel_Room_Management_System.Controllers
{
    public class RoomsController : Controller
    {
        AppDbContext context = new AppDbContext();

        public IActionResult Index()
        {
            var rooms = context.Rooms.ToList();
            ViewBag.Bookings = context.Bookings.ToList();
            return View(rooms);
            
        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            var room = context.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            return View("Edit", room);
        }

        [HttpPost]
        public IActionResult EditCurrent(Room roomFromView)
        {
            if (ModelState.IsValid == true)
            {
                context.Rooms.Update(roomFromView);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Edit", roomFromView);

            }

        }
            [HttpGet]
        public IActionResult GetCreateView()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult AddNew(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            var room = context.Rooms.Find(id);
            if(room == null)
            {
                return NotFound();
            }
            ViewBag.Bookings = context.Bookings.ToList();
            return View("Details", room);
        }

        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Room room = context.Rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", room);
            }
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            Room room = context.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }



            context.Rooms.Remove(room);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
