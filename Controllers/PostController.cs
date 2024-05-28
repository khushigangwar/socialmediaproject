using Microsoft.AspNetCore.Mvc;
using socialmediaproject.Models;
using socialmediaproject.Repo.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace socialmediaproject.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PostController : Controller
    {

        private readonly IPostRepo _postRepo;
        public PostController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetPost(int userId)
        {
            var post = await _postRepo.GetpostById(userId);
            return Ok(post);
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Create(Post post)

        {
             string result = await _postRepo.Create(post);

            return Ok(result);
        }
    }
}
