using SkillsetRank.Models;

namespace SkillsetRank.Services
{
    public interface ISkillsetRankService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string uid);
        Task<int> AddEmployee(Employee employee);
        Task<int> DeleteEmployee(string uid);
        Task UpdateEmployee(Employee employee);
    }
}
