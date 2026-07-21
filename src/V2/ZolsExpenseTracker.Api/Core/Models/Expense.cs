using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZolsExpenseTracker.Api;

namespace ZolsExpenseTracker.Api.Models
{
   public class Expense
   {
      [Key]
      public Guid Id { get; set; }

      [Required]
      public CategorySelection Category { get; set; }

      [Required]
      public string? Description { get; set; }

      [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than Zero.")]
      public double Amount { get; set; }

      [Required]
      public DateTime Date { get; set; }

      public bool IsExpense { get; set; }

      public Expense()
      {

      }
      public Expense(CategorySelection category, string? description, double amount, DateTime date)
      {
         Id = Guid.NewGuid();
         Category = category;
         Description = description;
         Amount = amount;
         Date = date;

         if (category == default(CategorySelection))
            throw new ArgumentException("Category is required.");
         if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");
         if (amount <= 0)
            throw new ArgumentException("Amount must be higher than 0.00");
         if (date == DateTime.MinValue)
            throw new ArgumentException("Date is required.");
      }
   }
}