using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApp.Models
{
    public interface INoteRepository
    {
        Note GetNote(int Id);
        IEnumerable<Note> GetAllNotes();
        Note Add(Note n);
        Note Update(Note noteChanges);
        Note Delete(int Id);
    }
}
