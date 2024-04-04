using System;

public static class TableHelper
{
    public static void PrintMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("0 - Exit");
        Console.WriteLine("1 - View reservations");
        Console.WriteLine("2 - Make a reservation");
        Console.WriteLine("3 - Cancel a reservation");
        Console.Write("Enter your choice: ");
    }
    

    public static void PrintTable(Reservation[,] table)
    {
        string[] daysOfWeek = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        Console.WriteLine("     | 10.00 | 11.00 | 12.00 | 13.00 | 14.00 | 15.00 | 16.00 | 17.00 | 18.00 | 19.00 |");
        Console.WriteLine("-----+-------+-------+-------+-------+-------+-------+-------+-------+-------+-------+");
        for (int i = 0; i < 7; i++)
        {
            Console.Write($" {daysOfWeek[i]} |");
            for (int j = 0; j < 10; j++)
            {
                if(table[i, j] == null)
                    Console.Write("   -   |");
                else
                    Console.Write($"{table[i, j].Room.roomName.PadRight(7)}|");
            }
            Console.WriteLine();
            Console.WriteLine("-----+-------+-------+-------+-------+-------+-------+--------+------+-------+-------+");
        }
    }

    public static void MakeReservation(ref ReservationHandler Reservations, ref RoomData RoomData)
    {
        int room;
        int day;
        int time;

        Console.WriteLine("Your name: ");
        string name = Console.ReadLine();
        Console.Clear();

        while(true){
            Console.WriteLine("Please select a room:");
            Console.WriteLine("1 - A-101");
            Console.WriteLine("2 - A-102");
            Console.WriteLine("3 - A-103");
            Console.WriteLine("4 - A-104");
            Console.WriteLine("5 - A-105");
            Console.WriteLine("6 - A-106");
            Console.WriteLine("7 - A-107");
            Console.WriteLine("8 - A-108");
            Console.WriteLine("9 - A-109");
            Console.WriteLine("10 - A-110");
            Console.WriteLine("11 - A-111");
            Console.WriteLine("12 - A-112");
            Console.WriteLine("13 - A-113");
            Console.WriteLine("14 - A-114");
            Console.WriteLine("15 - A-115");
            Console.WriteLine("16 - A-116");

            int.TryParse(Console.ReadLine(), out room);
            Console.Clear();

            if(room < 1 || room > 16){
                    Console.WriteLine("Please enter between 1 and 16");
                    continue;
            }
            break;
        }

        while(true){
            Console.WriteLine("Please select a day:");
            Console.WriteLine("1 - Mon");
            Console.WriteLine("2 - Tue");
            Console.WriteLine("3 - Wed");
            Console.WriteLine("4 - Thu");
            Console.WriteLine("5 - Fri");
            Console.WriteLine("6 - Sat");
            Console.WriteLine("7 - Sun");

            int.TryParse(Console.ReadLine(), out day);
            Console.Clear();

            if(day < 1 || day > 7){
                    Console.WriteLine("Please enter between 1 and 7");
                    continue;
            }
            break;
        }
        
        while(true){
            Console.WriteLine("Please select time:");
            Console.WriteLine("1 - 10.00");
            Console.WriteLine("2 - 11.00");
            Console.WriteLine("3 - 12.00");
            Console.WriteLine("4 - 13.00");
            Console.WriteLine("5 - 14.00");
            Console.WriteLine("6 - 15.00");
            Console.WriteLine("7 - 16.00");
            Console.WriteLine("8 - 17.00");
            Console.WriteLine("9 - 18.00");
            Console.WriteLine("10 - 19.00");

            int.TryParse(Console.ReadLine(), out time);
            Console.Clear();

            if(time < 1 || time > 10){
                    Console.WriteLine("Please enter between 1 and 10");
                    continue;
            }
            break;
        }

        Reservations.AddReservation(name, room-1, day-1, time-1, RoomData.Rooms[room-1]);
    }


    public static void ViewReservations(ref ReservationHandler Reservations)
    {  
        Reservations.DisplayWeekSchedule();
    }

    public static void CreateReservations(ref ReservationHandler Reservations, ref RoomData RoomData)
    {
        Reservations.AddReservation("Şeyma", 15, 6, 9, RoomData.Rooms[15]);
        Reservations.AddReservation("Şeyma", 15, 1, 5, RoomData.Rooms[15]);
        Reservations.AddReservation("Can", 0, 5, 7, RoomData.Rooms[0]);
        Reservations.AddReservation("Deniz", 1, 4, 3, RoomData.Rooms[1]);
        Reservations.AddReservation("Ceren", 2, 1, 0, RoomData.Rooms[2]);
        Reservations.AddReservation("Hüseyin", 3, 6, 4, RoomData.Rooms[3]);
        Reservations.AddReservation("Gizem", 4, 3, 1, RoomData.Rooms[4]);
        Reservations.AddReservation("Burak", 5, 2, 5, RoomData.Rooms[5]);
        Reservations.AddReservation("Merve", 6, 0, 8, RoomData.Rooms[6]);
        Reservations.AddReservation("Efe", 7, 6, 2, RoomData.Rooms[7]);
        Reservations.AddReservation("Elif", 8, 6, 1, RoomData.Rooms[8]);
        Reservations.AddReservation("Kaan", 9, 5, 9, RoomData.Rooms[9]);
        Reservations.AddReservation("Esra", 10, 4, 7, RoomData.Rooms[10]);
        Reservations.AddReservation("Oğuz", 11, 3, 4, RoomData.Rooms[11]);
        Reservations.AddReservation("Nazlı", 12, 2, 0, RoomData.Rooms[12]);
        Reservations.AddReservation("Berk", 13, 1, 6, RoomData.Rooms[13]);
        Reservations.AddReservation("Şeyma", 14, 0, 3, RoomData.Rooms[14]);
        Reservations.AddReservation("Can", 0, 5, 1, RoomData.Rooms[0]);
        Reservations.AddReservation("Deniz", 1, 6, 8, RoomData.Rooms[1]);
        Reservations.AddReservation("Hüseyin", 3, 3, 2, RoomData.Rooms[3]);
        Reservations.AddReservation("Gizem", 4, 2, 9, RoomData.Rooms[4]);
        Reservations.AddReservation("Burak", 5, 1, 7, RoomData.Rooms[5]);
        Reservations.AddReservation("Merve", 6, 0, 5, RoomData.Rooms[6]);
        Reservations.AddReservation("Efe", 7, 6, 3, RoomData.Rooms[7]);
        Reservations.AddReservation("Elif", 8, 5, 0, RoomData.Rooms[8]);
        Reservations.AddReservation("Kaan", 9, 4, 8, RoomData.Rooms[9]);
        Reservations.AddReservation("Esra", 10, 3, 6, RoomData.Rooms[10]);
        Reservations.AddReservation("Oğuz", 11, 2, 4, RoomData.Rooms[11]);
        Reservations.AddReservation("Nazlı", 12, 1, 2, RoomData.Rooms[12]);
        Reservations.AddReservation("Berk", 13, 0, 9, RoomData.Rooms[13]);
        Reservations.AddReservation("Şeyma", 14, 6, 7, RoomData.Rooms[14]);
        Reservations.AddReservation("Can", 0, 5, 5, RoomData.Rooms[0]);
        Reservations.AddReservation("Gizem", 4, 2, 2, RoomData.Rooms[4]);
        Reservations.AddReservation("Burak", 5, 1, 9, RoomData.Rooms[5]);
        Reservations.AddReservation("Merve", 6, 0, 7, RoomData.Rooms[6]);
        Reservations.AddReservation("Efe", 7, 6, 5, RoomData.Rooms[7]);
        Reservations.AddReservation("Elif", 8, 5, 3, RoomData.Rooms[8]);
        Reservations.AddReservation("Kaan", 9, 4, 0, RoomData.Rooms[9]);
        Reservations.AddReservation("Esra", 10, 3, 8, RoomData.Rooms[10]);
        Reservations.AddReservation("Oğuz", 11, 2, 6, RoomData.Rooms[11]);
        Reservations.AddReservation("Nazlı", 12, 1, 4, RoomData.Rooms[12]);
        Reservations.AddReservation("Berk", 13, 0, 2, RoomData.Rooms[13]);

        Console.Clear();
    }



    public static void DeleteReservation(ref ReservationHandler Reservations)
    {   
        Reservations.DeleteReservation(4, 2, 9);
        Reservations.DeleteReservation(5, 1, 7);
        Reservations.DeleteReservation(6, 0, 5);
        Reservations.DeleteReservation(7, 6, 3);
        Reservations.DeleteReservation(8, 5, 0);
        Reservations.DeleteReservation(9, 4, 8);
        Reservations.DeleteReservation(10, 3, 6);
        Reservations.DeleteReservation(11, 2, 4);
        Reservations.DeleteReservation(12, 1, 2);
    }

}