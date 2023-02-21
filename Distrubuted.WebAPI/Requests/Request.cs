namespace Distrubuted.WebAPI.Requests
{
    public record RegisterRequest(string Name, string Surname, string Email);
    public record LoginRequest(string Email, string Password);
}
