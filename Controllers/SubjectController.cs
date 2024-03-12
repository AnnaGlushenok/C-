using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers {
	[Authorize(Roles = "Admin")]
	public class SubjectController : Controller {
		private SubjectService subjectService;
		public SubjectController(SubjectService subjectService) =>
			this.subjectService = subjectService;
		// GET:
		public ActionResult Index() {
			var subjects = subjectService.FindAll();
			return View("Index", subjects);
		}

		// GET: SubjectController/Create
		public ActionResult Create() {
			return View("addSubject");
		}

		// POST: SubjectController/Create
		[HttpPost]
		public ActionResult Create(SubjectDTO subject) {
			if (ModelState.IsValid) {
				subjectService.Add(subject);
				return RedirectToAction(nameof(Index));
			}
			return View(subject);
		}

		// GET: SubjectController/Edit/5
		public ActionResult Edit(int id) {
			SubjectDTO subject = subjectService.FindAll().FirstOrDefault(s => s.Id == id);
			return View("editSubject", subject);
		}

		// POST: SubjectController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(SubjectDTO subject) {
			if (ModelState.IsValid) {
				subjectService.Update(subject);
				return RedirectToAction(nameof(Index));
			}
			return View("editSubject");
		}

		// GET: SubjectController/Delete/5
		[HttpDelete]
		public void Delete(int id) {
			subjectService.Delete(id);
		}
	}
}
