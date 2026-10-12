
using Microsoft.AspNetCore.Mvc;
using Unit4_MVC_rec.Models;

namespace Unit4_MVC_rec.Controllers
{
    public class StudentController : Controller
    {

        IStudentCRUDInterface studentRepo = new StudentRepository();
        public StudentController()
        {

        }

        public IActionResult Index()
        {
            return View(studentRepo.getAllStudents());
        }

        public IActionResult Details(int id)
        {
            IStudentInterface? student = studentRepo.getStudentById(id);
            if (student == null || student.Id == -1)
            {
                return NotFound();
            }
            return View("Details", student);
        }

        public IActionResult Add()
        {
            return View(new StudentModel(0, string.Empty, 0));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentModel student)
        {
            if (studentRepo.getStudentById(student.Id) is IStudentInterface existingStudent
                && existingStudent.Id != -1)
            {
                ModelState.AddModelError(nameof(student.Id), "A student with this ID already exists.");
            }

            studentRepo.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            IStudentInterface? student = studentRepo.getStudentById(id);
            if (student == null || student.Id == -1)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudentModel student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            IStudentInterface? existingStudent = studentRepo.getStudentById(id);
            if (existingStudent == null || existingStudent.Id == -1)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            studentRepo.UpdateStudent(id, student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            IStudentInterface? student = studentRepo.getStudentById(id);
            if (student == null || student.Id == -1)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            IStudentInterface? student = studentRepo.getStudentById(id);
            if (student == null || student.Id == -1)
            {
                return NotFound();
            }

            studentRepo.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
