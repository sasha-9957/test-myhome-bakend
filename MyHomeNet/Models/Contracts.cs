namespace MyHomeNet.Models;

public class Contracts
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

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
        public string? AccessToken { get; set; }
        public bool? EmailConfirmed { get; set; }
    }
    
    public static ApiResponse ExceptionToApiResponse(ChannelsApiExceptions.ChannelsApiException ex) =>
        new()
        {
            ErrorCode = ex.Source,
            Message = ex.Message,
        };
}
