using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Galaxy.Storage.DataBase
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private readonly string server = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234";
        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            optionBuilder.UseNpgsql(server, b => b.MigrationsAssembly("Galaxy.Storage"));
            return new DataContext(optionBuilder.Options);
        }
    }
}
