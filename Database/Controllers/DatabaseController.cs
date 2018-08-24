using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database.Data;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        private readonly ContextBase _db;
        
        public DatabaseController(ContextBase db)
        {
            _db = db;
        }

        [HttpGet("{table}")]
        public IActionResult GetTable(string table)
        {
            return Ok();
        }
    }
}
