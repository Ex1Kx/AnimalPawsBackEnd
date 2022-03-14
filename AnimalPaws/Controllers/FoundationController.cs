using AnimalPaws.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalPaws.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FoundationController : Controller
    {
        private readonly FoundationInterface _foundation;

        public FoundationController(FoundationInterface foundationInterface)
        {
            _foundation = foundationInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetFundaciones()
        {
            return Ok(await _foundation.GetFoundation()); 
        }
    }
}
