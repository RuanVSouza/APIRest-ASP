using Microsoft.EntityFrameworkCore;

namespace APIRest_ASP.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        
        public DbSet<Person> persons { get; set; }


    }
}
