using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        void Delete(int id);
        List<Booking> GetAll();
        List<Booking> GetFutureBookings();
        Booking? GetById(int id);
        void Update(Booking booking);
        //Task Update(Booking booking);
    }

}
