using __Hotel_Room_Management_System.Data;
using __Hotel_Room_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace __Hotel_Room_Management_System.Controllers
{
    public class BookingsController : Controller
    {
        AppDbContext context = new AppDbContext();
        public IActionResult Index()
        {
            var bookings = context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .ToList();

            return View(bookings);
        }

        [HttpGet]
        public IActionResult GetCreateView()
        {
                var rooms = context.Rooms.ToList();
    var customers = context.Customers.ToList();

    ViewBag.Rooms = rooms;
    ViewBag.Customers = customers;
            return View("Create");
        }


        [HttpPost]
        public IActionResult AddNew(Booking booking)
        {
            ModelState.Remove("Room");
            ModelState.Remove("Customer");

            // 1. Validate dates
            if (booking.CheckOut <= booking.CheckIn)
            {
                ModelState.AddModelError(
                    "",
                    "Check-Out must be after Check-In."
                );
            }
            else
            {
                // 2. Check room availability
                bool roomIsBooked = context.Bookings.Any(b =>
                    b.RoomId == booking.RoomId &&
                    booking.CheckIn < b.CheckOut &&
                    booking.CheckOut > b.CheckIn
                );

                if (roomIsBooked)
                {
                    ModelState.AddModelError(
                        "",
                        "This room is already booked for these dates."
                    );
                }
            }

            // 3. If there are errors, return Create
            if (!ModelState.IsValid)
            {
                ViewBag.Rooms = context.Rooms.ToList();
                ViewBag.Customers = context.Customers.ToList();

                return View("Create", booking);
            }

            // 4. Save
            context.Bookings.Add(booking);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            var booking = context.Bookings.Find(id);

            if (booking == null)
            {
                return NotFound();
            }
            ViewBag.Rooms = context.Rooms.ToList();
            ViewBag.Customers = context.Customers.ToList();

            return View("Edit", booking);
        }


        [HttpPost]
        public IActionResult EditCurrent(Booking bookingFromView)
        {
            ModelState.Remove("Room");
            ModelState.Remove("Customer");

            bool roomIsBooked = context.Bookings.Any(b =>
                b.Id != bookingFromView.Id &&
                b.RoomId == bookingFromView.RoomId &&
                bookingFromView.CheckIn < b.CheckOut &&
                bookingFromView.CheckOut > b.CheckIn
            );

            if (roomIsBooked)
            {
                ModelState.AddModelError("", "This room is already booked for these dates.");

                ViewBag.Rooms = context.Rooms.ToList();
                ViewBag.Customers = context.Customers.ToList();

                return View("Edit", bookingFromView);
            }

            if (ModelState.IsValid)
            {
                context.Bookings.Update(bookingFromView);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Rooms = context.Rooms.ToList();
            ViewBag.Customers = context.Customers.ToList();

            return View("Edit", bookingFromView);
        }

        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Booking booking = context.Bookings
                .Include(b => b.Room)
                .Include(b => b.Customer)
                .FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", booking);
            }
        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            Booking booking = context.Bookings.Find(id);

            if (booking == null)
            {
                return NotFound();
            }



            context.Bookings.Remove(booking);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }







    }
}
