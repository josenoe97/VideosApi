using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VideosApi.Data;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VideoController : ControllerBase
    {
        private VideoContext _context;
        private IMapper _mapper;

        public VideoController(VideoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostVideo([FromBody] CreateVideoDto dto)
        {
            Video video = _mapper.Map<Video>(dto);

            _context.Videos.Add(video);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), 
                new {id = video.Id},
                video);
        }

        [HttpGet]
        public IEnumerable<ReadVideoDto> GetVideo([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadVideoDto>>(_context.Videos.Skip(skip).Take(take).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id )
        {
            var video = _context.Videos.FirstOrDefault(video =>
            video.Id == id);

            if (video == null) return NotFound("Não encontrado.");

            var videoDto = _mapper.Map<ReadVideoDto>(video);

            return Ok(videoDto);
        }

        [HttpPut("{id}")]
        public IActionResult PutById(int id, [FromBody] UpdateVideoDto dto)
        {
            var video = _context.Videos.FirstOrDefault(video =>
            video.Id == id);

            if(video == null) return NotFound();

            _mapper.Map(dto, video);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(int id,
            JsonPatchDocument<UpdateVideoDto> patch) 
        {
            var video = _context.Videos.FirstOrDefault(video =>
                video.Id == id);
            if (video == null) return NotFound();

            var videoToUpdate = _mapper.Map<UpdateVideoDto>(video);

            patch.ApplyTo(videoToUpdate, ModelState);

            if (!TryValidateModel(videoToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(videoToUpdate, video);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var video = _context.Videos.FirstOrDefault(video =>
                video.Id == id);
            if (video == null) return NotFound();

            _context.Remove(video);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
