namespace post.models;

public record Post
{
    public int PostId { get; set; }

    public int UserId { get; set; }
     public string WrittenText { get; set; }
     public string MediaLocation { get; set; }
    // public DateTimeOffset CreatedDatetime { get; set; }
}