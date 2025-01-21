using HR_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HR.Data
{
    public class HR_Context:DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<City> citys { get; set; }
        public DbSet<UniverCity> univers { get; set; }
        public DbSet<Salary> salaries { get; set; }
        public DbSet<Vacation> vacations { get; set; }
        public DbSet<Leave_Balances> balances { get; set; }
        public DbSet<Rewards> rewards { get; set; }
        public DbSet<Penalties> penalties { get; set; }

       

        public HR_Context(DbContextOptions<HR_Context> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(x => x.departments)
                .WithMany(x => x.employees)
                .UsingEntity<EmployeeDepartment>();

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.salaries)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}


