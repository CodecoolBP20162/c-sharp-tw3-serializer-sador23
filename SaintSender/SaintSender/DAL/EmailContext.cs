using System.Data.Entity;
using SaintSender.Models;

namespace SaintSender.DAL
{
    public class EmailContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}