using Microsoft.EntityFrameworkCore;
using Todo_assginment.Models;

namespace Todo_assginment.Repository
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
