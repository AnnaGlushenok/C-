using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers {
	[Authorize(Roles = "Admin")]
	public class StudentController : Controller {
		private StudentService studentService;
		public StudentController(StudentService studentService) =>
			this.studentService = studentService;

		// GET:
		public ActionResult Index() {
			var students = studentService.FindAll();
			return View("Index", students);
		}

		public ActionResult Create() {
			return View("addStudent");
		}

		// POST: StudentController/Create
		[HttpPost]
		public ActionResult Create(string surname, string name, string patronymic) {
			if (ModelState.IsValid) {
				studentService.Add(new StudentDTO { Surname = surname, Name = name, Patronymic = patronymic });
				return RedirectToAction(nameof(Index));
			}
			return View("addStudent");
		}

		//GET StudentController/Edit/5
		public ActionResult Edit(int id) {
			StudentDTO student = studentService.FindAll().FirstOrDefault(s => s.Id == id);
			return View("editStudent", student);
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(StudentDTO student) {
			if (ModelState.IsValid) {
				studentService.Update(student);
				return RedirectToAction(nameof(Index));
			}
			return View("editStudent");
		}

		// POST: StudentController/Delete/5
		[HttpPost]
		public ActionResult Delete(int id) {
			studentService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

		public ActionResult Error() =>
			 View("error");
	}
}
