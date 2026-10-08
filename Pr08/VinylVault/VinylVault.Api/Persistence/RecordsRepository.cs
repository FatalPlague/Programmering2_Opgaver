using VinylVault.Api.Data;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Persistence
{
    public class RecordsRepository : IRecordsRepository
    {
        private readonly VinylVaultContext _context;

        public RecordsRepository(VinylVaultContext context)
        {
            _context = context;
        }

        public List<Record> GetAll()
        {
            return _context.Records.ToList();
        }
    }
}
