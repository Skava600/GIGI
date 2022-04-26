using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_953501_Skavarodnik.Data;
using Web_953501_Skavarodnik.Entities;

namespace Web_953501_Skavarodnik.Areas.Admin.Pages
{
    [Authorize(Roles ="admin")]
    public class IndexModel : PageModel
    {
        private readonly Web_953501_Skavarodnik.Data.ApplicationDbContext _context;

        public IndexModel(Web_953501_Skavarodnik.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Drink> Drink { get;set; }

        public async Task OnGetAsync()
        {
            Drink = await _context.Drinks
                .Include(d => d.Group).ToListAsync();
        }
    }
}
