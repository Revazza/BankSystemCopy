namespace InternetBank.Models.Requests;

public class RegisterUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}