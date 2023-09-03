
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebAPIProject.Entities
{
    public class StandardRepository : IStandardRepository
    {
        private readonly EFCoreDbContext _context;
        public StandardRepository(EFCoreDbContext context)
        {
            _context = context;
        }
        public Standard? GetStandardById(int id)
        {
            return _context.Standards.Find(id);
        }

        public List<Standard> GetStandards()
        {
            return _context.Standards.ToList();
        }
    }
}