using AnimalPaws.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalPaws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostInterface _posts;

        public PostController(PostInterface postInterface)
        {
            _posts = postInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnuncios()
        {
            return Ok(await _posts.GetPosts());
        }
    }
}
