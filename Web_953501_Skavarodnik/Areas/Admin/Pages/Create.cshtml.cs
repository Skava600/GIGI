using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_953501_Skavarodnik.Entities;

namespace Web_953501_Skavarodnik.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Web_953501_Skavarodnik.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CreateModel(Web_953501_Skavarodnik.Data.ApplicationDbContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["DrinkGroupId"] = new SelectList(_context.DrinkGroups, "DrinkGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Drink Drink { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drinks.Add(Drink);
            await _context.SaveChangesAsync();
            if (Image != null)
            {
                var fileName = $"{Drink.DrinkId}" +
                Path.GetExtension(Image.FileName);
                Drink.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
