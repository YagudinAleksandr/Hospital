using DataContext.Entities;
using DataContext.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository<Patient> repository;

        public PatientsController(IPatientRepository<Patient> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Patient>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<Patient>))]
        public async Task<IActionResult> GetDoctor(int id)
        {
            return await repository.GetAsync(id) is { } item
                ? Ok(new BaseResponseDTO<Patient>(200, true, null, item))
                : NotFound(new BaseResponseDTO<Patient>(404, false, "Врач не найден", null));
        }

        [HttpGet("{pageNumber}/{pageSize}/{sortField}/{isAscending}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Pagination<Patient>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDoctors(int pageNumber, int pageSize, string sortField, bool isAscending)
        {
            return await repository.GetAllAsync(pageNumber, pageSize, sortField, isAscending) is { } item
                ? Ok(new BaseResponseDTO<Pagination<Patient>>(200, true, null, item))
                : BadRequest(new BaseResponseDTO<string>(400, false, "Возникла ошибка при получении списка врачей", null));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseResponseDTO<Patient>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseDTO<Patient>))]
        public async Task<IActionResult> CreateDoctor([FromBody] Patient doctor) => await repository.CreateAsync(doctor) is { } item
                ? Ok(new BaseResponseDTO<Patient>(201, true, null, item))
                : BadRequest(new BaseResponseDTO<Patient>(400, false, "Не удалось создать врача", null));

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Patient>))]
        public async Task<IActionResult> DeleteDoctor([FromBody] Patient doctor)
        {
            await repository.DeleteAsync(doctor);
            return Ok(new BaseResponseDTO<string>(200, true, "Врач удален успешно", null));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Patient>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseDTO<Patient>))]
        public async Task<IActionResult> UpdateDoctor([FromBody] Patient doctor)
        {
            return await repository.UpdateAsync(doctor) is { } item
                ? Ok(new BaseResponseDTO<Patient>(200, true, null, item))
                : BadRequest(new BaseResponseDTO<Patient>(400, false, "Не удолось обновить врача", null));
        }
    }
}
