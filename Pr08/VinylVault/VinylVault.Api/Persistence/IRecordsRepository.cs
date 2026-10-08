using VinylVault.Shared.Models;

namespace VinylVault.Api.Persistence
{
    public interface IRecordsRepository
    {
        List<Record> GetAll();
    }
}
