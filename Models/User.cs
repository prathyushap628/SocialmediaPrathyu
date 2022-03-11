using own.DTOs;

namespace Dotnetsql.Models;


public record User
{
    public long UserId { get; set; }

    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public string Country { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public string GivenName { get; set; }
    public string Surname { get; set; }

   public UserDTO asDto{
       get{
           return new UserDTO{
              UserId = UserId,
              EmailAddress = EmailAddress,
              Password = Password,
              Country = Country,
              GivenName = GivenName,
              Surname = Surname,

              
           };
       }
   }

}