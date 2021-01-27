using Collections.Controllers;
using Collections.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Models.Item
{

    public class ItemController : BaseController
    {

        private readonly AppDbContext _db;

        [HttpGet("{like}")]
        public IActionResult FullTextSearch()
        {
            return View();
        }
    }
}