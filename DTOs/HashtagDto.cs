using System.Text.Json.Serialization;
using post.Dtos;

namespace hashtag.models;
public record HashtagDto
{
    public int HashtagId { get; set; }
    [JsonPropertyName("hashtag_name")]
    public string HashtagName { get; set; }

    public List<PostDto> posts{get;set;}
    
}