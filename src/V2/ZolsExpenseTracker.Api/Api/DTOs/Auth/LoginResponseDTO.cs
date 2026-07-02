using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace ZolsExpenseTracker.Api.DTOs.Auth
{
    public class LoginResponseDTO
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public DateAndTime ExpirationDate { get; set; }

       // public  JWTToken { get; set; }
    }
}