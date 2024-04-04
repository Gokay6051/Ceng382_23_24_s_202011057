public class ReservationHandler
{
    private Reservation[,] reservations;

    public ReservationHandler(int rows, int cols)
    {
        reservations = new Reservation[rows, cols];
        //Console.WriteLine($"{reservations[0,0]}");
    }

    public void AddReservation(string name, int row, int day, int time, Room room)
    {
        if(reservations[day, time] != null){
            Console.WriteLine("Not available");
            Console.WriteLine($"{reservations[row,day*time]}");
        }
        else{
            reservations[day, time] = new Reservation(room, time, day, name);
            Console.WriteLine("Reservation completed successfully!");
            //Console.WriteLine($"{reservations[row,day*time]}");
        }
    }


    public void DeleteReservation(int row, int day, int time)
    {
        if(reservations[day, time] == null){
            //Console.WriteLine("Reservation does not exist!");
        }
        else{
            reservations[day, time] = null;
            //Console.WriteLine("Reservation deleted successfully!");
        }
    }

    public void DisplayWeekSchedule()
    {   
        TableHelper.PrintTable(reservations);
    }
}
