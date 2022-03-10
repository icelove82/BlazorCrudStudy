namespace BlazorCrudStudy.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        public List<SuperHero> Heros { get; set; }
        public List<Comic> Comics { get; set; }

        Task GetSuperHeros();
        Task GetComics();
        Task<SuperHero> GetSingleHero(int id);
        Task CreateHero(SuperHero hero);
        Task UpdateHero(SuperHero hero);
        Task DeleteHero(int id);
    }
}
