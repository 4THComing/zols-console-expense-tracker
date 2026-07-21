using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZolsExpenseTracker.Api;

namespace ZolsExpenseTracker.Api.Models
{
    public class User
    {
        [Key]
        public Guid AuthId { get; set; }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public User()
        {

        }
        public User(string? name, string? email, string? password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");
        }
    }
}