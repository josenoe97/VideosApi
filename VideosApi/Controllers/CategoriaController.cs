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
    public class CategoriaController : ControllerBase
    {
        private VideoContext _context;
        private IMapper _mapper;

        public CategoriaController(VideoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostCategoria([FromBody] CreateCategoriaDto dto)
        {
            Categoria categoria = _mapper.Map<Categoria>(dto);

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                new { id = categoria.Id },
                categoria);
        }

        [HttpGet]
        public IEnumerable<ReadCategoriaDto> GetCategoria([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadCategoriaDto>>(_context.Categorias.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoria = _context.Videos.FirstOrDefault(categoria =>
            categoria.Id == id);

            if (categoria == null) return NotFound();

            var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);

            return Ok(categoriaDto);
        }

        [HttpPut("{id}")]
        public IActionResult PutById(int id, [FromBody] UpdateCategoriaDto dto)
        {
            var categoria = _context.Videos.FirstOrDefault(categoria =>
            categoria.Id == id);

            if (categoria == null) return NotFound();

            _mapper.Map(dto, categoria);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchById(int id,
            JsonPatchDocument<UpdateCategoriaDto> patch)
        {
            var categoria = _context.Videos.FirstOrDefault(categoria =>
                categoria.Id == id);
            if (categoria == null) return NotFound();

            var categoriaToUpdate = _mapper.Map<UpdateCategoriaDto>(categoria);

            patch.ApplyTo(categoriaToUpdate, ModelState);

            if (!TryValidateModel(categoriaToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(categoriaToUpdate, categoria);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(categoria =>
                categoria.Id == id);
            if (categoria == null) return NotFound();

            _context.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
