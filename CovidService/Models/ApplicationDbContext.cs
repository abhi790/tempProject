using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CovidService.Entities;

namespace CovidService.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

       
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //entities

        public DbSet<CovidDetails>? CovidDetails { get; set; }
        //configuraion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DotNetFSD\\SQLEXPRESS;Initial Catalog=CaseStudyDB;MultipleActiveResultSets=true;Persist Security Info=True;User ID=sa;Password=pass@123");
        }

    }

}
