using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApp.Models
{
    public class SQLNoteRepository : INoteRepository
    {
        private readonly AppDbContext context;
        public SQLNoteRepository(AppDbContext context)
        {
            this.context = context;
        }
        Note INoteRepository.Add(Note n)
        {
            context.NoteDetails.Add(n);
            context.SaveChanges();
            return n;
        }
        Note INoteRepository.Delete(int Id)
        {
            Note student = context.NoteDetails.Find(Id);
            if (student != null)
            {
                context.NoteDetails.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        IEnumerable<Note> INoteRepository.GetAllNotes()
        {
            return context.NoteDetails;
        }

        Note INoteRepository.GetNote(int id)
        {
            return context.NoteDetails.FirstOrDefault(m => m.id == id);
        }

        Note INoteRepository.Update(Note noteChanges)
        {
            var student = context.NoteDetails.Attach(noteChanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return noteChanges;
        }
    }
}
