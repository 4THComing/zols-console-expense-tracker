using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Models;

    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }

