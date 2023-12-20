namespace net_ita_2_checkpoint.DTOs
{
    public class UpdateRoomDTO
    {
        public Guid Id = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int People { get; set; }
        public decimal Price { get; set; }
    }
}