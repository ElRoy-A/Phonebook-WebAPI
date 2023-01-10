using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Models;

namespace PhonebookAPI.Data
{
    public class PhonebookAPIDbContext : DbContext
    {
        public PhonebookAPIDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
