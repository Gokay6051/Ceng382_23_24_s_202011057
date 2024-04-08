using System;

public record LogRecord
{
    private int Timestamp {get; init;}
    private string ReserverName {get; init;}
    private string roomName {get; init;}
}