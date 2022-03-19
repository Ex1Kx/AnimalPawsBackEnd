using AnimalPaws.Data.Repositories;
using AnimalPaws.Model;
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
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Posts posts)
        {
            if (posts == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _posts.uploadPost(posts);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> updatePost([FromBody] Posts posts)
        {
            if (posts == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _posts.updatePost(posts);
            return NoContent();
        }
        [HttpDelete("{idpost}")]
        public async Task<IActionResult> DeletePost(int idpost)
        {
            await _posts.deletePost(new Posts() { idpost = idpost });

            return NoContent();
        }
    }
}
