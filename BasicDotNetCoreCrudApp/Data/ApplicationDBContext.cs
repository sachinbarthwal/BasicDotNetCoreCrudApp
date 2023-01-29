using BasicDotNetCoreCrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicDotNetCoreCrudApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<CategoryModel> Categories { get; set; }

    }
}
