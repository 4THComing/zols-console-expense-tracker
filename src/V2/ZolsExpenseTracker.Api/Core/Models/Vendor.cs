using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZolsExpenseTracker.Api;

namespace ZolsExpenseTracker.Api.Models
{
    public class Vendor
    {
        [Key]
        public Guid AuthId { get; set;}

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        public Vendor()
        {

        }
        public Vendor(string? name, string? email, string? phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone Number is required.");
        }
    }
}