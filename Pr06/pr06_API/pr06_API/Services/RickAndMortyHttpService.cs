using pr06_API.Contracts;
using pr06_API.Models;
using pr06_API.ViewModels;
using System.ComponentModel;

namespace pr06_API.Services
{
    public class RickAndMortyHttpService : IRickAndMortyHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RickAndMortyHttpService(IHttpClientFactory httpcClientFactory)
        {
            _httpClientFactory = httpcClientFactory;
        }

        public async Task<CharacterViewModel> GetCharacterByIdAsync(int id)
        {
            using var httpclient = _httpClientFactory.CreateClient("RickAndMorty");

            // her bruger GetAsync så vi kan se på responsen. Vi kan komme til at parse et id som ikke eksistere.
            var httpResponse = await httpclient.GetAsync($"character/{id}");
            
            try
            {
                if (httpResponse == null)
                {
                    return null;
                }
            
                httpResponse.EnsureSuccessStatusCode();
                CharacterViewModel characterVM = new CharacterViewModel
                {
                    Character = await httpResponse.Content.ReadFromJsonAsync<Character>()
                };

                return characterVM;
            }
            catch
            {
                return new CharacterViewModel {
                    ErrorMessage = "Not found"
                };
            }            
        }

        public async Task<AllCharactersViewModel> GetAllCharactersAsync()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("RickAndMorty");

                var hej = DateTime.

                //her kan vi bruge HttpClient.GetFromJsonAsync() fordi vi ved at alle 43 sider eksitere
                // Så længe vi har skrevet det rigtige endpoint og APi'en ikke er nede (og det kan vi ikke styrer) virker det her helt fint.

                //Med den første response henter vi også antal af sider der er.

                var allCharactersViewModel = new AllCharactersViewModel();
                //allCharactersViewModel.CharacterResponse.Characters = new List<Character>();
                var response = await httpClient.GetAsync("character/");
                response.EnsureSuccessStatusCode();

                allCharactersViewModel.CharacterResponse = await response.Content.ReadFromJsonAsync<CharacterResponse>();



                return allCharactersViewModel;
            }
            catch
            {
                return new AllCharactersViewModel
                {
                    ErrorMessage = "Something went wrong"
                };
            }
        }
    }
}
