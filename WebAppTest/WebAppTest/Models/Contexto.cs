using Microsoft.EntityFrameworkCore;

namespace WebAppTest.Models
{
    public class Contexto : DbContext
    {
        public DbSet<UsersModel> Users { get; set; }

        public Contexto(DbContextOptions<Contexto> options): base(options)
        {

        }

    }
}
