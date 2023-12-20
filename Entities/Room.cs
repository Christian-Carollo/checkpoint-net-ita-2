namespace net_ita_2_checkpoint.Entities
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int People { get; set; }

       

    }
}