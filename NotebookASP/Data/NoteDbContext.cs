using Microsoft.EntityFrameworkCore;
using NotebookASP.Models;

namespace NotebookASP.Data
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Note { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
            => dbContextOptions.UseSqlite("Filename=NoteDB.db");
        
    }
}
