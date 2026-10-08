using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylVault.Api.Persistence;
using VinylVault.Shared.DTOs;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsRepository _recordsRepository;
        public RecordsController(IRecordsRepository recordsRepository)
        {
            _recordsRepository = recordsRepository;
        }

        // GET: api/records
        [HttpGet]
        public IActionResult GetAll()
        {
            var records = _recordsRepository.GetAll();
            var recordDtos = records.Where(r => r.IsGolden is false).Adapt<List<RecordReadDto>>();

            return Ok(recordDtos);
        }

        // GET api/records/golden
        [Authorize]
        [HttpGet("golden")]
        public IActionResult GetGoldenRecords()
        {
            var records = _recordsRepository.GetAll();
            var recordDtos = records.Where(r => r.IsGolden).Adapt<List<RecordReadDto>>();

            return Ok(recordDtos);
        }
    }
}
