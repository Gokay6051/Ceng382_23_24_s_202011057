using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomData
{
    [JsonPropertyName("Room")]
    public required Room[] Rooms {get; set;}
}
public class Room
{
    [JsonPropertyName("roomId")]
    public required string roomId {get; set;}
    [JsonPropertyName("roomName")]
    public required string roomName {get; set;}
    [JsonPropertyName("capacity")]
    public required int Capacity {get; set;}
}

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