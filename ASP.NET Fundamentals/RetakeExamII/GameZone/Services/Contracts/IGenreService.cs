namespace GameZone.Services.Contracts
{
    using Models.Genre;

    public interface IGenreService
    {
        Task<ICollection<GenreViewModel>> AllAsync();

        Task<bool> ExistAsync(int genreId);
    }
}
