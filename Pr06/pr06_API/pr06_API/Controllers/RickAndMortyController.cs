using Microsoft.AspNetCore.Mvc;
using pr06_API.Contracts;
using pr06_API.Models;
using pr06_API.ViewModels;

namespace pr06_API.Controllers
{
    public class RickAndMortyController : Controller
    {
        private readonly IRickAndMortyHttpService rickAndMortyHttpService;
        public RickAndMortyController(IRickAndMortyHttpService rickAndMortyHttpService)
        {
            this.rickAndMortyHttpService = rickAndMortyHttpService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Character(int id)
        {
            CharacterViewModel characterVM = await rickAndMortyHttpService.GetCharacterByIdAsync(id);

            return View(characterVM);
        }

        public async Task<IActionResult> AllCharacters()
        {
            AllCharactersViewModel allCharactersVM = await rickAndMortyHttpService.GetAllCharactersAsync();

            return View(allCharactersVM);
        }

    }
}
