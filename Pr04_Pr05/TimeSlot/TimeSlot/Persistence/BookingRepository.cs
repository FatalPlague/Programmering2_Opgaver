using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TimeSlotContext context;

        public BookingRepository(TimeSlotContext context)
        {
            this.context = context;
        }

        public void Add(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Bookings.Where(b => b.BookingId == id).ExecuteDelete();
        }

        public List<Booking> GetAll()
        {
            return context.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .ToList();
        }
        public List<Booking> GetFutureBookings()
        {
            return context.Bookings
                .Where(b => b.EndTime > DateTime.Now)
                .OrderBy(b => b.EndTime)
                .Include(b => b.Room)
                .Include(b => b.User)
                .ToList();
        }

        public Booking? GetById(int id)
        {
            return context.Bookings.FirstOrDefault(b => b.BookingId == id);
        }

        public void Update(Booking booking)
        {

            if (booking == null) throw new ArgumentNullException(nameof(booking));
            var bookingToBeUpdated = context.Bookings.Find(booking.BookingId);
            

            if (bookingToBeUpdated == null)
                throw new InvalidOperationException("Booking not found");

            // Tell EF the original RowVersion came from the client so it will be part of the WHERE clause
            //Dette for det til at virker af en eller anden guds forladt grund...

            context.Entry(bookingToBeUpdated)
                .Property(b => b.RowVersion)
                .OriginalValue = booking.RowVersion;

            bookingToBeUpdated.Title = booking.Title;
            bookingToBeUpdated.StartTime = booking.StartTime;
            bookingToBeUpdated.EndTime = booking.EndTime;
            bookingToBeUpdated.RoomId = booking.RoomId;
            //bookingToBeUpdated.RowVersion = booking.RowVersion;

            // SaveChanges will throw DbUpdateConcurrencyException on a concurrency conflict
            context.SaveChanges();
        }
    }
}
