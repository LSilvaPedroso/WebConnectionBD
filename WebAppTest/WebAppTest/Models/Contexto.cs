using Microsoft.EntityFrameworkCore;

namespace WebAppTest.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
