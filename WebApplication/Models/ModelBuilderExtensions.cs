using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id= 1,
                    Name = "Mark",
                    Department = Dept.IT,
                    Email = "mark@pragimtech.com"
                },
                new Employee
                {
                    Id= 2,
                    Name = "John",
                    Department = Dept.IT,
                    Email = "john@pragimtech.com"
                }
                
            );
        }
    }
}