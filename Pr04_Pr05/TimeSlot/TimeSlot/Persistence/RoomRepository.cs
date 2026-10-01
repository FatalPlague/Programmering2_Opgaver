using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private TimeSlotContext context;
        public RoomRepository(TimeSlotContext context)
        {
            this.context = context;
        }

        public void Add(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Rooms.Where(r => r.RoomId == id).ExecuteDelete();
        }

        public List<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Room? GetById(int id)
        {
            return context.Rooms.FirstOrDefault(r => r.RoomId == id);
        }

        public void Update(Room room)
        {
            context.Rooms.Where(r => r.RoomId == room.RoomId).ExecuteUpdate(r => r
                .SetProperty(r => r.Name, room.Name)
                .SetProperty(r => r.Capacity, room.Capacity)
                );
        }
    }
}
