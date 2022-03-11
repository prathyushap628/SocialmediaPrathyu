using post.models;

namespace hashtag.models;
public record Hashtag
{
    public int HashtagId { get; set; }
    public string HashtagName { get; set; }
    //  public int PostId { get; set; }
    // public int UserId { get; set; }

    public List<Post> posts { get; set; }

}