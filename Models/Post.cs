namespace socialmediaproject.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int postId { get; set; }
        public string Content{ get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
