using Microsoft.AspNetCore.Mvc;
using SkillsetRank.Models;
using SkillsetRank.Services;

namespace SkillsetRank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsetRankController : Controller
    {
        private readonly ISkillsetRankService _skillsetRankService;

        public SkillsetRankController(ISkillsetRankService skillsetRankService)
        {
            _skillsetRankService = skillsetRankService;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _skillsetRankService.GetEmployees();

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("employee")]
        public async Task<IActionResult> GetEmployee(string uid)
        {
            try
            {
                var employee = await _skillsetRankService.GetEmployee(uid);

                if(employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("employee/add")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await _skillsetRankService.AddEmployee(model);
                    if (empId > 0)
                    {
                        return Ok(empId);
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("employee/delete")]
        public async Task<IActionResult> DeletePost(string? uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
                return BadRequest();
            }

            try
            {
                var result = await _skillsetRankService.DeleteEmployee(uid);
                if (result == 0)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("employee/update")]
        public async Task<IActionResult> UpdatePost([FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _skillsetRankService.UpdateEmployee(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
