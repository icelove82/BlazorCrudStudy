using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCrudStudy.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<SuperHero> Heros { get ; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task CreateHero(SuperHero hero)
        {
            var res = await _http.PostAsJsonAsync("api/superhero", hero);
            var data = await res.Content.ReadFromJsonAsync<List<SuperHero>>();

            if (data != null)
                Heros = data;

            /* Back to list */
            _navigationManager.NavigateTo("superheros");
        }

        public async Task DeleteHero(int id)
        {
            var res = await _http.DeleteAsync($"api/superhero/{id}");
            var data = await res.Content.ReadFromJsonAsync<List<SuperHero>>();

            if (data != null)
                Heros = data;

            /* Back to list */
            _navigationManager.NavigateTo("superheros");
        }

        public async Task GetComics()
        {
            var res = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (res != null)
                Comics = res;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var res = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (res != null)
                return res;

            throw new Exception("Hero not found.");
        }

        public async Task GetSuperHeros()
        {
            var res = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (res != null)
                Heros = res;
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var res = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            var data = await res.Content.ReadFromJsonAsync<List<SuperHero>>();

            if (data != null)
                Heros = data;

            /* Back to list */
            _navigationManager.NavigateTo("superheros");
        }
    }
}
