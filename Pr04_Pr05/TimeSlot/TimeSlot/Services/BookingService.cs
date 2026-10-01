using System.Reflection.Metadata.Ecma335;
using System.Timers;
using TimeSlot.Models;
using TimeSlot.Persistence;

namespace TimeSlot.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public Booking GetById(int id)
        {
            return bookingRepository.GetById(id)!;
        }
        public List<Booking> GetAll()
        {
            return bookingRepository.GetAll();
        }
        
        public List<Booking> GetFutureBookings()
        {
            return bookingRepository.GetFutureBookings();
        }

        public BookingResult Add(Booking booking)
        {
            BookingResult result = IsBookingValid(booking);
            if (result.IsSuccelful)
                bookingRepository.Add(booking);
            return result;
        }

        public BookingResult Update(Booking booking)
        {
            BookingResult result = IsBookingValid(booking);
            if (result.IsSuccelful)
                bookingRepository.Update(booking);
            return result;
        }

        public void Delete(int id)
        {
            bookingRepository.Delete(id);
        }

        private BookingResult IsBookingValid(Booking booking)
        {
            BookingResult result = new BookingResult();

            if (booking.EndTime <= booking.StartTime)
            {
                result.Key = "Booking.EndTime";
                result.ErrorMessage = "End time has to be later than start time";
                return result;
            }
            else if (booking.StartTime.AddMinutes(5) < DateTime.Now)
            {
                result.Key = "Booking.StartTime";
                result.ErrorMessage = "Start time cannot be in the past";
                return result;
            }
            foreach (Booking checkBooking in bookingRepository.GetAll())
            {
                if (booking.BookingId != checkBooking.BookingId)
                {
                    // checks if booking starts inside another booking in the same room
                    if (booking.StartTime > checkBooking.StartTime && booking.StartTime < checkBooking.EndTime && booking.RoomId == checkBooking.RoomId)
                    {
                        result.Key = "Booking.StartTime";
                        result.ErrorMessage = "Room is not available for the selected time";
                        return result;
                    }
                    // checks if booking end in another booking in the same room
                    else if (booking.EndTime > checkBooking.StartTime && booking.EndTime < checkBooking.EndTime && booking.RoomId == checkBooking.RoomId)
                    {
                        result.Key = "Booking.EndTime";
                        result.ErrorMessage = "Room is not available for the selected time";
                        return result;
                    }
                    // checks if booking completely overlaps other booking in the same room
                    else if (booking.StartTime <= checkBooking.StartTime && booking.EndTime >= checkBooking.EndTime && booking.RoomId == checkBooking.RoomId)
                    {
                        result.Key = "Booking.RoomId";
                        result.ErrorMessage = "Room is not available for the selected time";
                        return result;
                    }
                }
                
            }
            result.IsSuccelful = true;
            return result;
        }

    }
}
