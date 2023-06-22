using Microsoft.EntityFrameworkCore;

namespace api_death_note.Models
{
    public class PersonagemContext : DbContext
    {
        public PersonagemContext(DbContextOptions<PersonagemContext> options): base(options)
        {

        }
        public DbSet<Personagens> Personagens { get; set; } = null!;
    }
}