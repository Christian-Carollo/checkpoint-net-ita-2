namespace net_ita_2_checkpoint.Entities
{
    public class Reservation
    {
        public Guid RoomId { get; set; }
        public DateTime Date { get; set; }
        public int People { get; set; }
        public Room? Room { get; set; }
    }
}