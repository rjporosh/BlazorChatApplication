using Microsoft.EntityFrameworkCore;

namespace BlazorChatApplication.Models
{
    public class ChatService
    {
        private readonly AppDbContext _context;

        public ChatService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> userList = new List<User>
                {
                    new User { Id = 1, Name = "Alice" },
                    new User { Id = 2, Name = "Bob" },
                    new User { Id = 3, Name = "Charlie" },
                    new User { Id = 4, Name = "David" },
                    new User { Id = 5, Name = "Eve" }
                };

            return userList;
        }

        public async Task<List<Message>> GetMessagesAsync(int senderId, int receiverId)
        {
            return await _context.Messages
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }
    }
}
