using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace app.Controllers {
	[Authorize(Roles = "User")]
	public class MarkController : Controller {
		private MarkService markService;
		private StudentService studentService;
		private SubjectService subjectService;
		public MarkController(MarkService markService, StudentService studentService, SubjectService subjectService) {
			this.markService = markService;
			this.studentService = studentService;
			this.subjectService = subjectService;
		}

		public ActionResult Index(MarkDTO mark) {
			var marks = markService.FindAll();
			var students = studentService.FindAll();
			var subjects = subjectService.FindAll();
			ViewBag.Students = new SelectList(students, "Id", "FullName");
			ViewBag.Subjects = new SelectList(subjects, "Id", "Name");
			if (mark == null)
				ViewBag.marks = marks;
			else {
				if (mark.SubjectId != 0)
					marks = marks.Where(m => mark.SubjectId == m.SubjectId).ToList();
				if (mark.StudentId != 0)
					marks = marks.Where(m => mark.StudentId == m.StudentId).ToList();
				ViewBag.marks = marks;
			}
			return View("Index");
		}

		// GET: MarkController/Create
		public ActionResult Create() {
			var students = studentService.FindAll();
			var subjects = subjectService.FindAll();
			ViewBag.Students = new SelectList(students, "Id", "FullName");
			ViewBag.Subjects = new SelectList(subjects, "Id", "Name");
			return View("addMark");
		}

		// POST: MarkController/Create
		[HttpPost]
		public ActionResult Create(MarkDTO mark) {
			mark.Date = DateTime.Now.ToShortDateString();
			markService.Add(mark);
			return RedirectToAction(nameof(Index));
		}

		// GET: MarkController/Edit/5
		public ActionResult Edit(int id) {
			Console.WriteLine(id);
			if (id == 0)
				return View("Error");

			var students = studentService.FindAll();
			var subjects = subjectService.FindAll();

			int StudentId = markService.FindAll().Find(x => x.Id == id).StudentId;
			var selectedStudent = students.Find(s => s.Id == StudentId);

			students.Remove(selectedStudent);
			students.Insert(0, selectedStudent);

			int SubjectId = markService.FindAll().Find(x => x.Id == id).SubjectId;
			var selectedSubject = subjects.Find(s => s.Id == SubjectId);

			subjects.Remove(selectedSubject);
			subjects.Insert(0, selectedSubject);

			ViewBag.Students = new SelectList(students, "Id", "FullName");
			ViewBag.Subjects = new SelectList(subjects, "Id", "Name");

			return View("editMark");
		}

		// POST: MarkController/Edit/5
		[HttpPost]
		public ActionResult Edit(MarkDTO mark) {
			mark.Date = markService.FindAll().FirstOrDefault(m => m.Id == mark.Id).Date;
			markService.Update(mark);
			return RedirectToAction(nameof(Index));
		}

		// GET: MarkController/Delete/5
		public ActionResult Delete(int id) {
			markService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
