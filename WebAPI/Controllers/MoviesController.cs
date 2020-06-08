using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Application.Repository.ConcreateRepositories;
using AutoMapper;
using Domain.Entity;
using Domain.VmModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //private readonly HadithRepository _hadith;
        private readonly IRepository<Hadith> _hadith;
        private readonly IMapper _mapper;      
        private readonly IUnitOfWork _unit;
        public MoviesController(IRepository<Hadith> hadith,IMapper mapper,IUnitOfWork unit)
        {
            _hadith = hadith;
            _mapper = mapper;
            _unit = unit;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<List<HadithVM>>> GetMovie()
        {
    
            var result = _hadith.Get();
           
            return await Task.Run(() => _mapper.Map<List<Hadith>, List<HadithVM>>(result));
        }

        //// GET: api/Movies/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Movie>> GetMovie(int id)
        //{
        //    var movie = await _context.Movie.FindAsync(id);

        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return movie;
        //}

        //// PUT: api/Movies/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMovie(int id, Movie movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(movie).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MovieExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Movies
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(HadithVM hadith)
        {

            HadithVM result=_mapper.Map<Hadith,HadithVM>( _hadith.Add(_mapper.Map<HadithVM,Hadith>(hadith)));

            await _unit.complateSaveAsync();

            return CreatedAtAction("GetMovie", result);
        }

        //// DELETE: api/Movies/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Movie>> DeleteMovie(int id)
        //{
        //    var movie = await _context.Movie.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Movie.Remove(movie);
        //    await _context.SaveChangesAsync();

        //    return movie;
        //}

        //private bool MovieExists(int id)
        //{
        //    return _context.Movie.Any(e => e.Id == id);
        //}
    }
}
