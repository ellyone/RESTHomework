using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DAL
{
    public class DataContext : DbContext
    {
        private DbSet<Customer> Customers { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}