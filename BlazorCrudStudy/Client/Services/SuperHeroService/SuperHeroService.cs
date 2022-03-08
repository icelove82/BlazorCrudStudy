using System.Net.Http.Json;

namespace BlazorCrudStudy.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;

        public SuperHeroService(HttpClient http)
        {
            _http = http;
        }

        public List<SuperHero> Heros { get ; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public Task GetComics()
        {
            throw new NotImplementedException();
        }

        public Task<SuperHero> GetSingleHero(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetSuperHeros()
        {
            var res = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (res != null)
                Heros = res;
        }
    }
}
