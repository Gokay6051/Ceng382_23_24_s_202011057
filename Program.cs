/*
    According to the Single Responsibility Principle, week 6 classes are weak, these are multi-task classes. At lab 7, we will    
*/

using System;
using System.Text.Json;
using System.Text.Json.Serialization;



class Program
{
    static int Main(string[]args)
    {
        
        //define file path
        string filePath = "Data.json";

        //Read from json
        //1 -> json to text // todo try catch
        string jsonString = File.ReadAllText(filePath);

        //2 -> decode text
        var RoomData = JsonSerializer.Deserialize<RoomData>(jsonString, new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        });
        
        ReservationHandler Reservations = new ReservationHandler(7, 10);

        //Adding reservations
        TableHelper.CreateReservations(ref Reservations, ref RoomData);

        
        TableHelper.ViewReservations(ref Reservations);

        TableHelper.DeleteReservation(ref Reservations);

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("After deleted some reservations");
        Console.WriteLine("");
        Console.WriteLine("");

        TableHelper.ViewReservations(ref Reservations);
        return 0;
    }
}