using Microsoft.EntityFrameworkCore;

namespace Project_CodeFirst
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions options): base(options)
        {

        }
        DbSet<AkhundovLibrary> AkhundovLibrary
        {
            get;set;
        }

        
    }
}
