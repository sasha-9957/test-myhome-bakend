namespace MyHomeNet.Models;

public class User
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public string? City { get; set; }
    public string? Company { get; set; }
    public string? ReferralCode { get; set; }
    public bool? EmailConfirmed { get; set; }
}