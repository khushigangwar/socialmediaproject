namespace socialmediaproject.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Registration> listRegistration { get; set; }
        public Registration Registration { get; set; }

    }
}
