using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_953501_Skavarodnik.Data;
using Web_953501_Skavarodnik.Entities;
using Web_953501_Skavarodnik.Extensions;
using Web_953501_Skavarodnik.Models;

namespace Web_953501_Skavarodnik.Controllers
{
    public class DrinkController : Controller
    {
        int _pageSize;
        ApplicationDbContext _context;
        public DrinkController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var drinksFiltered = _context.Drinks
                .Where(d => !group.HasValue || d.DrinkGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DrinkGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Drink>.GetModel(drinksFiltered, pageNo,_pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
    }
}
