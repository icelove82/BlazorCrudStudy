using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudStudy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic>
        {
            new Comic{ Id = 1, Name = "Marvel"},
            new Comic{ Id = 2, Name ="DC"}
        };

        public static List<SuperHero> heros = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                ComicId = 1,
                Comic = comics[0]
            },
            new SuperHero
            {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                ComicId = 2,
                Comic = comics[1]
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(heros);
        }

        /*[HttpGet]
        [Route("{id}")]*/
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = heros.FirstOrDefault(hero => hero.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            return Ok(comics);
        }
    }
}
