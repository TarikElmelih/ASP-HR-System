using AutoMapper;
using HR.Repositry;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IRepositryAllModels<City,CitySummary> repocity;
        private readonly IMapper mapper;

        public CityController(
            IRepositryAllModels<City, CitySummary> repocity,
            IMapper mapper
            )
        {
            this.repocity = repocity;
            this.mapper = mapper;
        }



        [HttpGet("/getAllCity")]
        public async Task<ActionResult<List<CitySummary>>> GetAllAsync()
        {
            var getAll= repocity.GetAll();
            return Ok(getAll);
        }


        [HttpGet("/GetCityId/{id}")]
        public async Task<ActionResult<EmployeeSummary>> GetCityById(Guid id)
        {
            var get = repocity.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/AddCity")]
        public async Task<ActionResult<CityCreation>> Add(CityCreation city)
        {
            var map = mapper.Map<City>(city);

            var added = await Task.Run(() => repocity.Add(map)); 

            return Ok(added);
        }


        [HttpPut("/api/PutCity/{id}")]
        public async Task<ActionResult<City>> PutEmployee(Guid id,[FromBody] City city)
        {
            repocity.Put(id,city);
            
            return NoContent();

        }

        [HttpDelete("/Deleted")]
        public async Task<ActionResult<City>>DeleteEmployee(Guid id)
        {
            var delete = repocity.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Employee Not Found ... ");
            }
            //var empdelete = mapper.Map<CitySummary>(delete);

            return NoContent(); 
        }



        // return List in Emplyee 
        [HttpGet("api/ListEmployee")]
        public async Task<ActionResult<List<Employee>>> GetListEmployeesInCity()
        {
            var getlsitEmp = repocity.GetEmployeesInCity();
            if(getlsitEmp is null)
            {
                return BadRequest(" ...  Null ");
            }
            var json=JsonConvert.SerializeObject(getlsitEmp, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }



        [HttpPatch("/api/City/Patch")]
        public async Task<ActionResult<City>> UpdateCity(Guid id, JsonPatchDocument<City> emp)
        {
            var patches = repocity.UpdateAsync(id, emp);
            if (patches == null)
            {
                return NotFound();
            }
            return Ok(patches);
        }



    }
}
