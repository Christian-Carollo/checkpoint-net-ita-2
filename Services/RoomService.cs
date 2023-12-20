using net_ita_2_checkpoint.Context;
using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Entities;
using net_ita_2_checkpoint.Services.Interfaces;

namespace net_ita_2_checkpoint.Services
{
    public class RoomService : IRoomService
    {
        private readonly IDbContext db;

        public RoomService(IDbContext db)
        {
            this.db = db;
        }

        public async Task CreateRoomAsync(CreateRoomDTO dto)
        {
             db.Rooms.Add(new Entities.Room { Name = dto.Name, Type= dto.Type, People= dto.People });
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            await Task.Run(() =>
            {
                
                var roomDeleted =  db.Rooms.FirstOrDefault(r => r.Id == id);
                if (roomDeleted == null) { throw new ArgumentNullException(nameof(roomDeleted), "invalid operation"); }
                db.Rooms.Remove(roomDeleted);
            });
            
 
        }

        public async Task<ICollection<RoomListDTO>> GetAllRoomsAsync()
        {
            return db.Rooms.Select(room => new RoomListDTO { Name = room.Name, Type = room.Type, People = room.People }).ToList();
              
        }

        public async Task<ICollection<RoomListDTO>> GetAvailableRoomsAsync(DateTime date)
        {
            return db.Rooms.Select(room => new RoomListDTO { Name = room.Name, Type = room.Type, People = room.People }).ToList();
        }

        public async Task<RoomDetailDTO> GetRoomAsync(Guid id)
        {
            var room = db.Rooms.Select(room => new RoomDetailDTO { Name = room.Name, Type = room.Type, People = room.People }).ToList().FirstOrDefault(r => r.Id == id);
            if (room == null) { throw new ArgumentNullException(nameof(room), "invalid operation"); }
            return room;
        }

        public async Task UpdateRoomAsync(UpdateRoomDTO dto)
        {
            var roomUpdate = db.Rooms.FirstOrDefault(r => r.Id == dto.Id);
            if(roomUpdate == null) { throw new ArgumentNullException(nameof(roomUpdate), "invalid operation"); }
            roomUpdate.Name = dto.Name;
            roomUpdate.Type = dto.Type;
            roomUpdate.People = dto.People;
        }

        public async Task DeleteAllRoomAsync()
        {
            db.Rooms.Clear();
        }

      
    }
}