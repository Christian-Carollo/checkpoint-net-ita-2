using net_ita_2_checkpoint.DTOs;

namespace net_ita_2_checkpoint.Services.Interfaces
{
    public interface IRoomService
    {
        Task<ICollection<RoomListDTO>> GetAllRoomsAsync();
        Task<ICollection<RoomListDTO>> GetAvailableRoomsAsync(DateTime date);
        Task<RoomDetailDTO> GetRoomAsync(Guid id);
        Task CreateRoomAsync(CreateRoomDTO dto);
        Task UpdateRoomAsync(UpdateRoomDTO dto);
        Task DeleteRoomAsync(Guid id);
        Task DeleteAllRoomAsync();
    }
}