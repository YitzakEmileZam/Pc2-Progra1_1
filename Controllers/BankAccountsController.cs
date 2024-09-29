using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankApp.Controllers
{
    [Route("[controller]")]
    public class BankAccountsController : Controller
    {
        //private readonly ILogger<BankAccountsController> _logger;
        private readonly ApplicationDbContext _context;

        // public BankAccountsController(ILogger<BankAccountsController> logger)
        // {
        //     _logger = logger;
        // }

        public BankAccountsController(ApplicationDbContext context){
            _context = context;
        }
    

        public IActionResult Index()
        {
            var accounts = _context.BankAccounts.ToList();
            return View(accounts);
        }

         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountHolderName,AccountType,InitialBalance,Email")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankAccount);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bankAccount);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}