﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using VideosApi.Data;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private VideoContext _context;
        private UsuarioController _userController;
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
        public IEnumerable<ReadVideoDto> GetVideo([FromQuery] int page)
        {
            
          

            var skip = page * 5;  // Page pular 5 em 5 video por pagina

                return _mapper.Map<List<ReadVideoDto>>(_context.Videos.Skip(skip).Take(5).ToList());
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
