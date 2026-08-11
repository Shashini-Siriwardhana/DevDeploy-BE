namespace ProjectService.Models
{
    public class ProjectItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RepositoryUrl { get; set; }
        public string Branch { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }    }
}