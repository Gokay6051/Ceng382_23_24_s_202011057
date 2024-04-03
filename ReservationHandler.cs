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
        if(reservations[row, (day*10)+time] != null){
            Console.WriteLine("Not available");
            Console.WriteLine($"{reservations[row,day*time]}");
        }
        else{
            reservations[row, (day*10)+time] = new Reservation(room, time, day, name);
            Console.WriteLine("Reservation completed successfully!");
            //Console.WriteLine($"{reservations[row,day*time]}");
            Console.WriteLine($"{row} , {(day*10)+time}");
        }
    }


    public void DeleteReservation(int row, int day, int time)
    {
        if(reservations[row, day*10+time] == null){
            Console.WriteLine("Reservation does not exist!");
        }
        else{
            reservations[row, day*10+time] = null;
            Console.WriteLine("Reservation deleted successfully!");
        }
    }

    public void DisplayWeekSchedule(int row)
    {
        string[,] schedule = new string[7, 10];

        for(int i=0; i<7; ++i){
            for(int j=0; j<10; ++j){
                if(reservations[row, i*10+j] == null)
                    schedule[i,j] = "   -";
                else
                    schedule[i,j] = reservations[row, i*10+j].ReserverName;
            }
            
        }
        TableHelper.PrintTable(schedule);
    }
}
