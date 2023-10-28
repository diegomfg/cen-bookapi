using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Repository;
using CEN4010_Bookstore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PublisherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublisherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Publisher> objCategoryList = _unitOfWork.Publisher.GetAll().ToList();
            return View(objCategoryList);
        }

        [HttpGet]
        public List<Publisher> GetPublishers()
        {
            List<Publisher> Publisher = _unitOfWork.Publisher.GetAll().ToList();
            return Publisher;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] Publisher obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Publisher.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Publisher created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Publisher? publisherFromDb = _unitOfWork.Publisher.Get(u => u.Id == id);
            if (publisherFromDb == null)
            {
                return NotFound();
            }
            return View(publisherFromDb);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Publisher obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Publisher.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Publisher updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 100)
            {
                return NotFound();
            }

            Publisher? publisherFromDb = _unitOfWork.Publisher.Get(u => u.Id == id);
            if (publisherFromDb == null)
            {
                return NotFound();
            }
            return View(publisherFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Publisher obj = _unitOfWork.Publisher.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Publisher.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Publisher deleted successfully";
            return RedirectToAction("Index");

        }

    }
}