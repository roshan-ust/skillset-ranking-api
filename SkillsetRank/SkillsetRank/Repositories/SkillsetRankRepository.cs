using Microsoft.EntityFrameworkCore;
using SkillsetRank.Models;

namespace SkillsetRank.Repositories
{
    public class SkillsetRankRepository : ISkillsetRankRepository
    {
        private readonly SkillsetContext _skillsetContext;

        public SkillsetRankRepository(SkillsetContext skillsetContext)
        {
            _skillsetContext = skillsetContext;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            try
            {
                await _skillsetContext.Employees.AddAsync(employee);
                await _skillsetContext.SaveChangesAsync();
                return employee.Id;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public async Task<int> DeleteEmployee(string uid)
        {
            int result = 0;

            try
            {
                var employee = await _skillsetContext.Employees.FirstOrDefaultAsync(emp => emp.Uid.Equals(uid));

                if (employee != null)
                {
                    _skillsetContext.Remove(employee);

                    result = await _skillsetContext.SaveChangesAsync();
                }

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<Employee> GetEmployee(string uid)
        {
            try
            {
                return await _skillsetContext.Employees.FirstOrDefaultAsync(emp => emp.Uid.Equals(uid));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _skillsetContext.Employees.ToListAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                _skillsetContext.Update(employee);
                await _skillsetContext.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await _skillsetContext.Skills.ToListAsync();
        }
    }
}
