using api_Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace api_Sqlite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }

}