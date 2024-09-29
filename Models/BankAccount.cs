using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankAccount
    {
    public int Id { get; set; }
    public string? AccountHolderName { get; set; }
    public string? AccountType { get; set; }
    public decimal? InitialBalance { get; set; }
    public string? Email { get; set; }
    }
}