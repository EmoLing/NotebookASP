using Microsoft.EntityFrameworkCore;
using NotebookASP.Data;
using NotebookASP.Models.Interfaces;

namespace NotebookASP.Models
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteDbContext _db;
        private bool disposed = false;

        public NoteRepository(NoteDbContext db)
        {
            _db = db;
        }

        public async Task CreateNote(Note note)
        {
            _db.Add(note);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllNotes() => await _db.Note.ToListAsync();

        public async Task<Note> GetNote(int? id) => await _db.FindAsync<Note>(id);

        public async Task UpdateNote(Note note)
        {
            _db.Update(note);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteNote(int id)
        {
            var note = _db.Note.Find(id);

            if (note is null)
                return false;

            _db.Note.Remove(note);

            return await _db.SaveChangesAsync() > 0;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _db.Dispose();
            }

            disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
