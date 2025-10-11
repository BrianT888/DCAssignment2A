using DCAssignment2A.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCAssignment2A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DBManager _context;

        public DatabaseController(DBManager context)
        {
            _context = context;
        }

        // GET: api/Database/Clear
        [HttpGet("Clear")]
        public async Task<IActionResult> ClearDatabase()
        {
            _context.Transactions.RemoveRange(_context.Transactions);
            _context.BankAccounts.RemoveRange(_context.BankAccounts);
            _context.UserProfiles.RemoveRange(_context.UserProfiles);
            await _context.SaveChangesAsync();

            return Ok("Database cleared successfully");
        }

        // GET: api/Database/Reseed
        [HttpGet("Reseed")]
        public async Task<IActionResult> ReseedDatabase()
        {
            // Clear first
            _context.Transactions.RemoveRange(_context.Transactions);
            _context.BankAccounts.RemoveRange(_context.BankAccounts);
            _context.UserProfiles.RemoveRange(_context.UserProfiles);
            await _context.SaveChangesAsync();

            // Seed new data
            DataSeeder.Seed(_context);

            return Ok("Database reseeded successfully");
        }
    }
}
