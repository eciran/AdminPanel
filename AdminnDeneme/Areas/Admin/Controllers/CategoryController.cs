using AdminnDeneme.Areas.Admin.Models.ResultModel;
using AdminnDeneme.Entity;
using AdminnDeneme.Repository;
using System;
using System.Web.Mvc;

namespace AdminnDeneme.Areas.Admin.Controllers
{
	public class CategoryController : Controller
	{
		private CategoryRepository cr = new CategoryRepository();
		private InstanceResult<Category> result = new InstanceResult<Category>();

		// GET: Admin/Category
		public ActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCategory(Category model)
		{
			model.CategoryID = Guid.NewGuid();
			result.resultint = cr.Insert(model);
			ViewBag.Mesaj = result.resultint.UserMessage;
			return RedirectToAction("List");
		}
		public ActionResult List()
		{
			result.resultList = cr.List();
			return View(result.resultList.ProcessResult);
		}
		[HttpGet]
		public ActionResult Edit(Guid id)
		{
			result.resultT = cr.GetObjById(id);
			return View(result.resultT.ProcessResult);
		}

		[HttpPost]
		public ActionResult Edit(Category model)
		{
			result.resultint = cr.Update(model);
			ViewBag.Mesaj = result.resultint.UserMessage;
			return RedirectToAction("List");
		}

		public ActionResult Delete(Guid id)
		{
			result.resultint = cr.Delete(id);
			return RedirectToAction("List", new { @mesaj = result.resultint.UserMessage });
		}
	}
}