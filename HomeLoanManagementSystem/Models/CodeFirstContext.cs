using Microsoft.EntityFrameworkCore;

namespace HomeLoanManagementSystem.Models
{
    public class CodeFirstContext:DbContext
    {
        public CodeFirstContext()
        {
                
        }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options):base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
    }
}
