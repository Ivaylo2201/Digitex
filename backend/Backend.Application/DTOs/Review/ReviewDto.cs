﻿namespace Backend.Application.DTOs.Review;

public record ReviewDto
{
    public required int Rating { get; init; }
    public string? Comment { get; init; }   
    public required string Username { get; init; }
    public required DateTime CreatedAt { get; init; }   
}