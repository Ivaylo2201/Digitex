namespace Backend.Application.Dtos.Review;

public class AddReviewDto
{
    public required int Rating { get; init; }
    public string? Comment { get; init; }   
    public Guid ProductId { get; set; }
    public int UserId { get; set; }   
}