using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<IEnumerable<Expense>> GetExpenseByIdAsync(Guid id);
        Task AddExpense(Expense expense);
        Task UpdateExpense(Expense expense);
        Task DeleteExpense(Expense expense);
        Task SaveExpense();
    }

    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseDbContext _context;

        public ExpenseRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(Guid id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task AddExpense(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task UpdateExpense(Expense expense)
        {
            await _context.Expenses.Update(expense);
        }

        public async Task DeleteExpense(Expense expense)
        {
            await _context.Expenses.Remove(expense);
        }

        public async Task SaveExpense()
        {
            await _context.SaveChangesAsync();
        }

    }
}
