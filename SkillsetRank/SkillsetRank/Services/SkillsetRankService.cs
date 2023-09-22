using SkillsetRank.Models;
using SkillsetRank.Repositories;

namespace SkillsetRank.Services
{
    public class SkillsetRankService : ISkillsetRankService
    {
        private readonly ISkillsetRankRepository _skillsetRankRepository;

        public SkillsetRankService(ISkillsetRankRepository skillsetRankRepository)
        {
            _skillsetRankRepository = skillsetRankRepository;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            return await _skillsetRankRepository.AddEmployee(employee);
        }

        public async Task<int> DeleteEmployee(string uid)
        {
            return await _skillsetRankRepository.DeleteEmployee(uid);
        }

        public async Task<Employee> GetEmployee(string uid)
        {
            return await _skillsetRankRepository.GetEmployee(uid);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _skillsetRankRepository.GetEmployees();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _skillsetRankRepository.UpdateEmployee(employee);
        }
    }
}
