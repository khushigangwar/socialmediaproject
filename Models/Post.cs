namespace socialmediaproject.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int postId { get; set; }
        public string ImageName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content{ get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
