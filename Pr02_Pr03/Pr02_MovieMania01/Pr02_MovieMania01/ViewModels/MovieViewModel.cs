using Pr02_MovieMania01.Models;
using Pr02_MovieMania01.Persistence;

namespace Pr02_MovieMania01.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; } = new();
        public List<Director> Directors { get; set; } = new();
    }
}
