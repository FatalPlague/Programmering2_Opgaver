using TimeSlot.Models;

namespace TimeSlot.Services
{
    public interface IBookingService
    {
        public Booking GetById(int id);
        public List<Booking> GetAll();
        List<Booking> GetFutureBookings();
        public BookingResult Add(Booking booking);
        public BookingResult Update(Booking booking);
        public void Delete(int id);

    }
}
