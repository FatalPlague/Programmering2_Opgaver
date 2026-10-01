using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TimeSlot.Data;
using TimeSlot.Migrations;
using TimeSlot.Models;
using TimeSlot.Persistence;
using TimeSlot.Services;
using TimeSlot.ViewModels;

namespace TimeSlot.Controllers
{
    [Authorize]
    //[Authorize(Roles = "Admin")]
    public class BookingsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private IRoomRepository roomRepository;
        private IBookingService bookingService;

        public BookingsController(IBookingService bookingService, IRoomRepository roomRepository, UserManager<ApplicationUser> userManager)
        {
            this.roomRepository = roomRepository;
            this.bookingService = bookingService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Booking> bookings;
            if (User.IsInRole("Admin"))
            {
                bookings = bookingService.GetFutureBookings();
            }
            else
            {
                
                bookings = bookingService.GetFutureBookings();
                bookings.RemoveAll(b => b.UserId != userManager.GetUserId(User));
            }
            
            return View(bookings);
        }

        public IActionResult Add(int? id)
        {
            ViewBag.Action = "add";

            var bookingVM = new BookingViewModel
            {
                Rooms = roomRepository.GetAll()
            };

            var date = DateTime.Now;
            bookingVM.Booking.StartTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
            bookingVM.Booking.EndTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);

            if (id != null) bookingVM.Booking.RoomId = id.Value;

            bookingVM.Booking.UserId = userManager.GetUserId(User);
            //bookingVM.Booking.RowVersion = 
            

            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult Add(BookingViewModel bookingVM)
        {
            bookingVM.Booking.User = userManager.Users.Where(u => u.Id == userManager.GetUserId(User)).FirstOrDefault();
            
            BookingResult result = bookingService.Add(bookingVM.Booking);
            if (!result.IsSuccelful)
            {
                ModelState.AddModelError(result.Key, result.ErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                bookingVM.Rooms = roomRepository.GetAll();
                ViewBag.Action = "add";

                return View(bookingVM);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            BookingViewModel bookingVM = new BookingViewModel
            {
                Booking = bookingService.GetById(id ?? 0),
                Rooms = roomRepository.GetAll()
            };
            //bookingVM.Booking.UserId = userManager.GetUserId(User);

            ViewBag.Action = "edit";

            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult Edit(BookingViewModel bookingVM)
        {
            BookingResult result = new BookingResult();
            try
            {
                result = bookingService.Update(bookingVM.Booking);

            }
            catch(Exception e)
            {
                if (e is DbUpdateConcurrencyException ex)
                {
                    ModelState.AddModelError("Booking.Title", "Denne Booking er blevet opdateret af nogen andre. For at kunne opdaterer den, skal du prøve igen.");

                    bookingVM.Rooms = roomRepository.GetAll();
                    ViewBag.Action = "edit";
                    return View(bookingVM);
                }
            }
            
            if (!result.IsSuccelful)
            {
                ModelState.AddModelError(result.Key, result.ErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                bookingVM.Rooms = roomRepository.GetAll();

                ViewBag.Action = "edit";

                return View(bookingVM);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bookingService.Delete(id);

            return RedirectToAction("Index");   
        }
    }
}
