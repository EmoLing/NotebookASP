using System;
namespace NotebookASP.Models.Interfaces
{
    public interface INoteRepository : IDisposable
    {
        public Task<IEnumerable<Note>> GetAllNotes();
        public Task<Note> GetNote(int? id);
        public Task CreateNote(Note note);
        public Task<bool> DeleteNote(int id);
        public Task UpdateNote(Note note);
    }
}
