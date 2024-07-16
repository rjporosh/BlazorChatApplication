namespace BlazorChatApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
