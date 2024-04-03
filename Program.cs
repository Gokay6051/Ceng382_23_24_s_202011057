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
        /*
        if(RoomData?.Rooms != null)
        {
            foreach(var room in RoomData.Rooms)
            {
                Console.WriteLine($"Room Id : {room.roomId} RoomName : {room.roomName} Capacity : {room.Capacity}");
            }
        }
        */

        

        ReservationHandler Reservations = new ReservationHandler(16, 70);

        //Adding reservations
        TableHelper.CreateReservations(ref Reservations, ref RoomData);

        int choice;
        while (true)
        {
            TableHelper.PrintMenu();
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                if(choice < 0 || choice > 3){
                    Console.WriteLine("Please enter between 0 and 3");
                }
                if(choice == 0){
                    Console.WriteLine("The program is over!");
                    break;
                }
                if(choice == 1){
                    TableHelper.ViewReservations(ref Reservations);
                }
                if(choice == 2){
                    TableHelper.MakeReservation(ref Reservations, ref RoomData);
                }
                if(choice == 3){
                    TableHelper.DeleteReservation(ref Reservations);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        return 0;
    }
}