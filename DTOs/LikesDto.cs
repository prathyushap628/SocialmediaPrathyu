namespace likes.models;

public record LikesDto
{
    public int LikesId { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }

    
  //  public DateTimeOffset CreatedDatetime { get; set; }
}