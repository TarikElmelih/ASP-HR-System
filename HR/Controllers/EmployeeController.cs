using AutoMapper;
using HR.Repositry;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositryAllModels<Employee,EmployeeSummary> repoEmp;
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<City,CitySummary> repoCity;
        private readonly RepoEmployee repo;
        private readonly IRepositryUpdate<Employee> repoupdate;

        public EmployeeController(
            IRepositryAllModels<Employee, EmployeeSummary> repoEmp,
            IMapper mapper,
            IRepositryAllModels<City, CitySummary> RepoCity,
            RepoEmployee repo,
            IRepositryUpdate< Employee> repoupdate
            )
        {
            this.repoEmp = repoEmp;
            this.mapper = mapper;
            repoCity = RepoCity;
            this.repo = repo;
            this.repoupdate = repoupdate;
        }


        [HttpGet]
        public async Task<ActionResult<List<EmployeeSummary>>> GetAllEmployee()
        {
            var gets = repoEmp.GetAll();

            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetEmployee/{id:guid}")]
        public async Task <ActionResult<EmployeeSummary>> GetEmployee(Guid id)
        {
            var get = repoEmp.GetById(id);
            return Ok(get);
        }  

        [HttpPost("/api/AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] EmployeeCreation employee)
        {
            var map = mapper.Map<Employee>(employee);

            var request = repoEmp.Add(map);
            return CreatedAtAction(nameof(GetAllEmployee), new { id = request.id }, map);
        }

        [HttpPut("/api/PutEmployee/{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(Guid id, [FromBody] Employee employee)
        {
            var updatedEmployee = await repoEmp.Put(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }

        [HttpDelete("Deleted")]
        public async Task<ActionResult<Employee>>DeleteEmployee(Guid id)
        {
            var delete =repoEmp.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Employee Not Found ... ");
            }
            var empdelete = mapper.Map<EmployeeSummary>(delete);

            return NoContent(); 
        }

        [HttpPatch("/api/Patch")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Guid id,JsonPatchDocument<Employee> emp)
        {
            var patches = repoEmp.UpdateAsync(id,emp);
            if (patches == null)
            {
                return NotFound();
            }
            return Ok(patches);
        }







     

      /// <summary>
      /// /////////////
      /// </summary>
      /// <returns></returns>

        [HttpGet("Api/EmployeeinSalarys")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeInSalarys()
        {
            var responce = repoEmp.GetAllEmplyeeAndSalarys();
            if (responce == null)
            {
                return BadRequest(" is Employee null City");
            }

            var json = JsonConvert.SerializeObject(responce, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            return Ok(json);
        }



        



        

    }


}


