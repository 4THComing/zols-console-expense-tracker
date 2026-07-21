using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZolsExpenseTracker.Api;

namespace ZolsExpenseTracker.Api.Models
{
    public class Auth
    {
        [Key]
        public Guid AuthId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User";

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime? LastLoginAt { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public Auth()
        {

        }

        public Auth(string username, string email, string passwordHash, string role = "User")
        {
            AuthId = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            LastLoginAt = null;
            IsActive = true;

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash is required.");
        }
    }
}