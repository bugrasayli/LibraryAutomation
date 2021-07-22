using Library.Domain.Entities;
using Library.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class LibraryContext : DbContext, IUnitOfWork
    {
        public LibraryContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Kind> Kind { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Costumer> Costumer{ get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
