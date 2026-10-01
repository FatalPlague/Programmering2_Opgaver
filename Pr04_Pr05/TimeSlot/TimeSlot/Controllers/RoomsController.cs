using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSlot.Persistence;

namespace TimeSlot.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private IRoomRepository roomRepository;
        public RoomsController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public IActionResult Index()
        {
            var rooms = roomRepository.GetAll();
            return View(rooms);
        }
    }
}
