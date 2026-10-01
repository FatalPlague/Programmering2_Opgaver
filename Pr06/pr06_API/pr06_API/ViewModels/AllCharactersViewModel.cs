using pr06_API.Models;
using System.Text.Json.Serialization;

namespace pr06_API.ViewModels
{
    public class AllCharactersViewModel
    {
        public CharacterResponse? CharacterResponse { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
