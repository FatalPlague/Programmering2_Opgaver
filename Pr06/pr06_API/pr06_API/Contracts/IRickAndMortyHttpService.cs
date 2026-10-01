using pr06_API.ViewModels;

namespace pr06_API.Contracts
{
    public interface IRickAndMortyHttpService
    {
        Task<CharacterViewModel> GetCharacterByIdAsync(int id);
        Task<AllCharactersViewModel> GetAllCharactersAsync();
    }
}
