using Microsoft.EntityFrameworkCore;
namespace ProjectService.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<ProjectItem> ProjectItem { get; set; }
    }
}