using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepo;
        int a;
        public NoteController(INoteRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }
        public IActionResult Index()
        {
            var model = _noteRepo.GetAllNotes();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            Note student = _noteRepo.GetNote(id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("NotFound", id);
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult NewNote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewNote(Note n)
        {
            if (ModelState.IsValid)
            {
                Note newStudent = _noteRepo.Add(n);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public ViewResult UpdateNote(int id)
        {
            Note student = _noteRepo.GetNote(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult UpdateNote(Note model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the Student being edited from the database
                Note student = _noteRepo.GetNote(model.id);
                // Update the Student object with the data in the model object
                student.noteTitle = model.noteTitle;
                student.noteDesc = model.noteDesc;
                // Call update method on the repository service passing it the
                // Student object to update the data in the database table
                Note updatedStudent = _noteRepo.Update(student);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteNote(int id)
        {
            Note student = _noteRepo.GetNote(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteNoteConfirmed(int id)
        {
            var student = _noteRepo.GetNote(id);
            _noteRepo.Delete(student.id);
            return RedirectToAction("Index");
        }
    }
}