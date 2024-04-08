using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public record RoomData
{
    [JsonPropertyName("Room")]
    public required Room[] Rooms {get; init;}
}
public class Room
{
    [JsonPropertyName("roomId")]
    public required string roomId {get; init;}
    [JsonPropertyName("roomName")]
    public required string roomName {get; init;}
    [JsonPropertyName("capacity")]
    public required int Capacity {get; init;}
}

