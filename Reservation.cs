using System;

public record Reservation
{
    public Room Room { get; init; }
    public int Time { get; init; }
    public int Date { get; init; }
    public string ReserverName { get; init; }
    //string[,] Reservations = new string[7, 10];
    
    public Reservation(Room room, int time, int date, string reserverName)
    {
        Room = room;
        Date = date;
        Time = time;
        ReserverName = reserverName;
        //TableHelper.InitializeTable(Reservations, ReserverName);
    }
}
