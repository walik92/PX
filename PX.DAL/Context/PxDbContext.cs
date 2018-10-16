using Microsoft.EntityFrameworkCore;
using PX.DAL.DTO;

namespace PX.DAL.Context
{
    public class PxDbContext : DbContext
    {
        public PxDbContext(DbContextOptions<PxDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}