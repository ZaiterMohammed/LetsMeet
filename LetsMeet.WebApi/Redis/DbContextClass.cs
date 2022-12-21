
namespace LetsMeet.WebApi.Redis
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.WebApi.RabbitMQ;
    using Microsoft.EntityFrameworkCore;

    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        { 
        }

        public DbSet<PostAction> PostAction
        {
            get;
            set;
        }
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
