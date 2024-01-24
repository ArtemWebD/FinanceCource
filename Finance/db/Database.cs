using Finance.models;
using Microsoft.EntityFrameworkCore;

namespace Finance.db
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<Change> Changes => Set<Change>();
        public DbSet<Purpose> Purposes => Set<Purpose>();
    }
}
