using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetUserByEmailAsync(string email);
		Task<IReadOnlyList<User>> GetUsersByTypeAsync(string userType);
	}
}
