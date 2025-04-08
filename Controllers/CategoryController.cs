using bulkyWeb.Data;
using bulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace bulkyWeb.Controllers

{
    public class CategoryController:Controller
    {

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET - CREATE
        public IActionResult Index()
        {

            List<Category> objList = _db.Category.ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {


            // custom validation can be done in this way but the basic default validation is sufficient in this case.
            //if ( obj.Name== obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            //}

            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError( "test is an invalid  value ");
            //}

            if (ModelState.IsValid) // this checks if the model(which object of Category created by user is valid or not), if it is not valid, then the database is not populated
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        //category editing logic
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Category.Find(id); // this works only for primary key
            //Category? categoryFromDb = _db.Category.FirstOrDefault(u => u.Id == id); // this works for any column in the table    



            if (categoryFromDb == null)
            {
                return NotFound();
            }
            // this is used to populate the form with the data of the category that is being edited 

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {


            // custom validation can be done in this way but the basic default validation is sufficient in this case.
            //if ( obj.Name== obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            //}

            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError( "test is an invalid  value ");
            //}

            if (ModelState.IsValid) // this checks if the model(which object of Category created by user is valid or not), if it is not valid, then the database is not populated
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
