namespace SkillMatch.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; } // "Student", "Employer", or "Admin"
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public StudentProfile? StudentProfile { get; set; }
        public EmployerProfile? EmployerProfile { get; set; }
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}