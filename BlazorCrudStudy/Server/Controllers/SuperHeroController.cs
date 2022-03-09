using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudStudy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            var heros = await _context.SuperHeroesV2
                .Include(h => h.Comic)
                .ToListAsync();
            return Ok(heros);
        }

        /*[HttpGet]
        [Route("{id}")]*/
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroesV2
                .Include(h => h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.ComicsV2.ToListAsync();
            return Ok(comics);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            hero.Comic = null;
            _context.SuperHeroesV2.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeros());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero hero)
        {
            var dbHero = await _context.SuperHeroesV2
                .Include(h => h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (dbHero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }

            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.HeroName = hero.HeroName;
            dbHero.ComicId = hero.ComicId;

            await _context.SaveChangesAsync();
            
            return Ok(await GetDbHeros());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.SuperHeroesV2
                .Include(h => h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (dbHero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }

            _context.Remove(dbHero);

            await _context.SaveChangesAsync();

            return Ok(await GetDbHeros());
        }

        private async Task<List<SuperHero>> GetDbHeros()
        {
            return await _context.SuperHeroesV2
                .Include(h => h.Comic)
                .ToListAsync();
        }
    }
}
