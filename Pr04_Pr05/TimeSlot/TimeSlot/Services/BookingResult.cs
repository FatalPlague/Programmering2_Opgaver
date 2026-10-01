namespace TimeSlot.Services
{
    public class BookingResult
    {
        public string Key { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsSuccelful { get; set; } = false;
    }
}
