using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_953501_Skavarodnik.Data;
using Web_953501_Skavarodnik.Entities;

namespace Web_953501_Skavarodnik.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Web_953501_Skavarodnik.Data.ApplicationDbContext _context;

        public DetailsModel(Web_953501_Skavarodnik.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drinks
                .Include(d => d.Group).FirstOrDefaultAsync(m => m.DrinkId == id);

            if (Drink == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
