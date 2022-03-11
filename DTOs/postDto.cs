using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using likes.models;

namespace post.Dtos;

public record PostDto
{
    [JsonPropertyName("post_id")]

    public int PostId { get; set; }
    [JsonPropertyName("user_id")]

    public int UserId { get; set; }
    [JsonPropertyName("written_text")]

    public string WrittenText { get; set; }


    [JsonPropertyName("media_location")]

    public string MediaLocation { get; set; }
    public List<LikesDto> Likes { get; internal set; }

    // public List<hashtag> MyProperty { get; set; }
    //[JsonPropertyName("created_datetime")]

    //public DateTimeOffset CreatedDatetime { get; set; }
}
public record PostCreateDto
{
    [JsonPropertyName("post_id")]
    [Required]
    [MaxLength(30)]
    public int PostId { get; set; }
    [JsonPropertyName("user_id")]
    [Required]
    [MaxLength(30)]

    public int UserId { get; set; }
    [JsonPropertyName("written_text")]
    [Required]
    [MaxLength(30)]
    public string WrittenText { get; set; }


    [JsonPropertyName("media_location")]
    [Required]
    [MaxLength(30)]
    public string MediaLocation { get; set; }
    // [JsonPropertyName("created_datetime")]
    // [Required]
    // [MaxLength(30)]
    // public DateTimeOffset CreatedDatetime { get; set; }
}