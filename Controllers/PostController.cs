using Microsoft.AspNetCore.Mvc;
using socialmediaproject.Models;
using socialmediaproject.Repo.Interfaces;
using static System.Net.Mime.MediaTypeNames;

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
        [HttpPost("upload")]
        public async  Task<IActionResult>Create([FromForm] IFormFile file, [FromForm] int userId)
 
     {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

using (var memoryStream = new MemoryStream())
{
    await file.CopyToAsync(memoryStream);
    var image = new Post
    {
        UserId = userId,
        ImageName = file.FileName,
        ContentType = file.ContentType,
        Content = memoryStream.ToArray(),
        CreatedDate = DateTime.UtcNow
    };

    var imageId = await _postRepo.Create(image);
    return Ok(new { ImageId = imageId });
}
    }

    }
}
