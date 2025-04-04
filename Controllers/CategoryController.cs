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
        public IActionResult index()
        {

            List<Category> objList = _db.Category.ToList();
            return View(objList);
        }
       

    }
}
