using Marina_Club.Context;

namespace Marina_Club.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MarinaClubContext _context;

        public BaseRepository(MarinaClubContext context)
        {
            _context = context;
        }
    }
}
