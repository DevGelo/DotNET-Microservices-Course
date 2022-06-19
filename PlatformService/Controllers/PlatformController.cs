using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository repository;
        private readonly IMapper mapper;

        public PlatformsController(IPlatformRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        //[Route("/platforms/")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
        {
            return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(repository.GetAll()));
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<PlatformReadDto> GetById(int id)
        {
            var platform = repository.GetById(id);
            if (platform != null)
                return Ok(mapper.Map<PlatformReadDto>(platform));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> Create(PlatformCreateDto data)
        {
            var platform = mapper.Map<Platform>(data);
            repository.Creat(platform);
            repository.SaveChanges();

            var created = mapper.Map<PlatformReadDto>(platform);
            return CreatedAtRoute(nameof(GetById), new {Id = created.Id}, created);
        }
    }
}