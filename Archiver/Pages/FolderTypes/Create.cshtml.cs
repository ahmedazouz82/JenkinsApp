using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Archiver.Data;
using Archiver.Models;

namespace Archiver.Pages.FolderTypes
{
    public class CreateModel : PageModel
    {
        private readonly Archiver.Data.ArchiverContext _context;

        public CreateModel(Archiver.Data.ArchiverContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DocFoldersType DocFoldersType { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DocFoldersType.Add(DocFoldersType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
