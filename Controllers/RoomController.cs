using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Entities;
using net_ita_2_checkpoint.Services.Interfaces;

namespace net_ita_2_checkpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly ILoggingService loggingService;
        private readonly IMemoryCache memoryCache;
        private const string roomKey = "room";
        private const string roomAllKey = "rooms";

        public RoomController(IRoomService roomService, ILoggingService loggingService, IMemoryCache memoryCache)
        {
            this.roomService = roomService;
            this.loggingService = loggingService;
            this.memoryCache = memoryCache;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            try
            {
                var room = await memoryCache.GetOrCreate($"{roomAllKey}", async entry =>
                {
                    return await roomService.GetAllRoomsAsync();
                    
                }); return Ok(room);

            }
            catch (Exception ex)
            {
                return loggingService.Log(ex.Message);
            }
            
        }

        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailableRoomsAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> GetRoomAsync(Guid id)
        {
            try
            {
                var room = await memoryCache.GetOrCreate($"{roomKey}-{id}", async entry =>
                {
                    return await roomService.GetRoomAsync(id);

                }); return Ok(room);
                
            }
            catch (Exception ex)
            {
                return loggingService.Log(ex.Message);
            }
            

        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostRoomAsync([FromBody] CreateRoomDTO dto)
        {
            try
            {
                await roomService.CreateRoomAsync(dto);
                return Ok("Room created");
            }
            catch(Exception ex)
            {
                return loggingService.Log(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> PutRoomAsync(Guid id, [FromBody] UpdateRoomDTO dto)
        {
            try
            {
                memoryCache.Remove($"{roomKey}-{id}");
                var roomUpdate =  roomService.UpdateRoomAsync(dto);
                await roomService.GetRoomAsync(id);
                return Ok(roomUpdate);
            }
            catch (Exception ex)
            {
                return loggingService.Log(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoomAsync(Guid id)
        {
            try
            {
                await roomService.DeleteRoomAsync(id);
                memoryCache.Remove($"{roomKey}-{id}");
                return Ok("Room deleted");
            }
            catch (Exception ex)
            {
                return loggingService.Log(ex.Message);
            }

        }

        [HttpDelete("All")]
        public async Task<IActionResult> DeleteAllRoomAsync()
        {
            try
            {
                memoryCache.Remove($"{roomAllKey}");
                await roomService.DeleteAllRoomAsync();
                return Ok("Rooms Deleted");
            }
            catch (Exception ex)
            {
                return loggingService.Log(ex.Message);
            }
        }
    }
    
}