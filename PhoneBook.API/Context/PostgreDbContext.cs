using Microsoft.EntityFrameworkCore;
using PhoneBook.API.Models;

namespace PhoneBook.API.Context
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
        {

        }
    }
}
