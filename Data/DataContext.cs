using Microsoft.EntityFrameworkCore;
using WebApi_Uygulama.Models;

namespace WebApi_Uygulama.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SIJUH3V;Database=WebApiDb;Trusted_Connection=True;");
        }
    }
}
