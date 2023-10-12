using LAB1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Data
{
    public class ForumDBContext : DbContext
    {
        public DbSet<ForumTopic> ForumTopics { get; set; } 
        public ForumDBContext(DbContextOptions options) : base(options) { }
    }
}
