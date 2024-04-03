using System;

public class Reservation
{
    public Room Room { get; set; }
    public int Time { get; set; }
    public int Date { get; set; }
    public string ReserverName { get; set; }
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
