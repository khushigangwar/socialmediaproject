namespace socialmediaproject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int postId { get; set; }
        public string ImageName { get; set; }
        public string ContentType { get; set; }
        public string Content{ get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
