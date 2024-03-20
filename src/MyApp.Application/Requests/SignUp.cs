namespace MyApp.Application.Requests;

public record SignUp(string Username, string Email, string Password, string FirstName, string LastName);