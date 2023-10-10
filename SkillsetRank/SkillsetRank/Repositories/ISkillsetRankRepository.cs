using SkillsetRank.Models;

namespace SkillsetRank.Repositories
{
    public interface ISkillsetRankRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string uid);
        Task<int> AddEmployee(Employee employee);
        Task<int> DeleteEmployee(string uid);
        Task UpdateEmployee(Employee employee);
        Task<IEnumerable<Skill>> GetSkills();
    }
}
