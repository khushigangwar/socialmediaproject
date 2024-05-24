using Microsoft.AspNetCore.Mvc;
using socialmediaproject.Repo.Interfaces;

namespace socialmediaproject.Controllers
{
    [Route("api/[controller]")]
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
            var post=await _postRepo.GetpostById(userId);
            return Ok(post);
        }

    }
}
