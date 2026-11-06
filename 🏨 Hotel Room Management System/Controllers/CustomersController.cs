using __Hotel_Room_Management_System.Data;
using __Hotel_Room_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace __Hotel_Room_Management_System.Controllers
{
    public class CustomersController : Controller
    {
        AppDbContext context = new AppDbContext();

        IWebHostEnvironment webHostEnvironment;
        public CustomersController(IWebHostEnvironment webHostEnv)
        {
            webHostEnvironment = webHostEnv;
        }
        public IActionResult Index()
        {
            var customers = context.Customers.ToList();
            return View(customers);
        }
        public IActionResult GetCreateView()
        {
            return View("Create");
        }


[HttpGet]
public IActionResult GetEditView(int id)
        {
            var customer = context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View("Edit", customer);
        }


        [HttpPost]
        public IActionResult EditCurrent(Customer customerFromEditView)
        {
            if (ModelState.IsValid == true)
            {
                // نجيب العميل القديم من Database
                var customerFromDb = context.Customers.Find(customerFromEditView.Id);

                if (customerFromDb == null)
                {
                    return NotFound();
                }

                // نحدث البيانات العادية
                customerFromDb.FullName = customerFromEditView.FullName;
                customerFromDb.Phone = customerFromEditView.Phone;

                // لو المستخدم اختار صورة جديدة
                if (customerFromEditView.ImageFile != null)
                {
                    Guid imageGuid = Guid.NewGuid();

                    string imageExtension =
                        Path.GetExtension(customerFromEditView.ImageFile.FileName);

                    string imageNewName = imageGuid + imageExtension;

                    customerFromDb.ImagePath = "\\images\\" + imageNewName;

                    string imageFullPath =
                        webHostEnvironment.WebRootPath + customerFromDb.ImagePath;

                    FileStream imageFileStream =
                        new FileStream(imageFullPath, FileMode.Create);

                    customerFromEditView.ImageFile.CopyTo(imageFileStream);

                    imageFileStream.Dispose();
                }

                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Edit", customerFromEditView);
            }
        }



        [HttpPost]
        public IActionResult AddNew(Customer customer)
        {
            if (ModelState.IsValid == true)
            {
                if (customer.ImageFile == null)
                {
                    customer.ImagePath = "\\images\\No_Image.png";
                }
                else
                {
                    Guid imageGuid = Guid.NewGuid();

                    string imageExtension =
                        Path.GetExtension(customer.ImageFile.FileName);

                    string imageNewName = imageGuid + imageExtension;

                    customer.ImagePath = "\\images\\" + imageNewName;

                    string imageFullPath =
                        webHostEnvironment.WebRootPath + customer.ImagePath;

                    FileStream imageFileStream =
                        new FileStream(imageFullPath, FileMode.Create);

                    customer.ImageFile.CopyTo(imageFileStream);

                    imageFileStream.Dispose();
                }

                context.Customers.Add(customer);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", customer);
            }
        }

        public IActionResult GetDetailsView(int id)
        {
            var customer = context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            var bookings = context.Bookings
                .Include(b => b.Room)
                .Where(b => b.CustomerId == id)
                .ToList();

            ViewBag.Bookings = bookings;
            return View("Details", customer);
        }

        
[HttpGet]
public IActionResult GetDeleteView(int id)
        {
            Customer customer = context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", customer);
            }
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            Customer customer = context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            if (customer.ImagePath != "\\images\\No_Image.png")
            {
                string imageFullPath =
                    webHostEnvironment.WebRootPath + customer.ImagePath;

                System.IO.File.Delete(imageFullPath);
            }

            context.Customers.Remove(customer);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }




    }
}
