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
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository<Doctor> repository;

        public DoctorsController(IDoctorRepository<Doctor> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Doctor>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<Doctor>))]
        public async Task<IActionResult> GetDoctor(int id)
        {
            return await repository.GetAsync(id) is { } item
                ?Ok(new BaseResponseDTO<Doctor>(200, true, null, item))
                :NotFound(new BaseResponseDTO<Doctor>(404, false, "Врач не найден", null));
        }

        [HttpGet("{pageNumber}/{pageSize}/{sortField}/{isAscending}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Pagination<Doctor>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDoctors(int pageNumber, int pageSize, string sortField, bool isAscending)
        {
            return await repository.GetAllAsync(pageNumber, pageSize, sortField, isAscending) is { } item
                ? Ok(new BaseResponseDTO<Pagination<Doctor>>(200, true, null, item))
                : BadRequest(new BaseResponseDTO<string>(400, false, "Возникла ошибка при получении списка врачей", null));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseResponseDTO<Doctor>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseDTO<Doctor>))]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor) => await repository.CreateAsync(doctor) is { } item
                ? Ok(new BaseResponseDTO<Doctor>(201, true, null, item))
                : BadRequest(new BaseResponseDTO<Doctor>(400, false, "Не удалось создать врача", null));

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Doctor>))]
        public async Task<IActionResult> DeleteDoctor([FromBody] Doctor doctor)
        {
            await repository.DeleteAsync(doctor);
            return Ok(new BaseResponseDTO<string>(200, true, "Врач удален успешно", null));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<Doctor>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseDTO<Doctor>))]
        public async Task<IActionResult> UpdateDoctor([FromBody] Doctor doctor)
        {
            return await repository.UpdateAsync(doctor) is { } item
                ? Ok(new BaseResponseDTO<Doctor>(200, true, null, item))
                : BadRequest(new BaseResponseDTO<Doctor>(400, false, "Не удолось обновить врача", null));
        }
    }
}
