using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PX.DAL.Context
{
    public class PxDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PxDbContext>
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BackendTestWalkowiak;Trusted_Connection=True;MultipleActiveResultSets=true";

        public PxDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PxDbContext>();
            builder.UseSqlServer(ConnectionString);

            return new PxDbContext(builder.Options);
        }
    }
}