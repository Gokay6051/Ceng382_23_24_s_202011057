public class Reservation
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public required Room room{ get; set; }

    public DateTime DateTime{ get; set; }

    public string ReservedBy{ get; set; }
}
