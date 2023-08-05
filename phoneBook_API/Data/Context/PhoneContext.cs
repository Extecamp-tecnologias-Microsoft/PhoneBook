using Microsoft.EntityFrameworkCore;
using phoneBook_API.Models;

namespace phoneBook_API.Data.Context
{
    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public PhoneContext(DbContextOptions<PhoneContext> opts) : base(opts) { }
    }
}
