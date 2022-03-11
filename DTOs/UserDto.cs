using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace own.DTOs;


public record UserDTO
{
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }


    [JsonPropertyName("given_name")]
    public string GivenName { get; set; }
    [JsonPropertyName("surname")]
    public string Surname { get; set; }

}

public record UserCreateDTO
{
  
    [JsonPropertyName("email_address")]
    [Required]
    [MaxLength(255)]
    public string EmailAddress { get; set; }
    [JsonPropertyName("password")]
    [Required]
    [MaxLength(8)]
    public string Password { get; set; }
    [JsonPropertyName("country")]
    [Required]
    [MaxLength(255)]
    public string Country { get; set; }
    
      [JsonPropertyName("date_of_birth")]
      [Required]
    
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("given_name")]
    [Required]
    [MaxLength(30)]
    public string GivenName { get; set; }
    [JsonPropertyName("surname")]
    [Required]
    [MaxLength(40)]
    public string Surname { get; set; }
     

}
public record UserUpadateDTO
{
  
     [JsonPropertyName("given_name")]
    [Required]
    [MaxLength(30)]
    public string GivenName { get; set; }
    [JsonPropertyName("surname")]
    [Required]
    [MaxLength(40)]
    public string Surname { get; set; }
     

}