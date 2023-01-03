using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Archiver.Data;
using Archiver.Models;

namespace Archiver.Pages.FolderTypes
{
    public class EditModel : PageModel
    {
        private readonly Archiver.Data.ArchiverContext _context;

        public EditModel(Archiver.Data.ArchiverContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DocFoldersType DocFoldersType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DocFoldersType == null)
            {
                return NotFound();
            }

            var docfolderstype =  await _context.DocFoldersType.FirstOrDefaultAsync(m => m.ID == id);
            if (docfolderstype == null)
            {
                return NotFound();
            }
            DocFoldersType = docfolderstype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DocFoldersType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocFoldersTypeExists(DocFoldersType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DocFoldersTypeExists(int id)
        {
          return _context.DocFoldersType.Any(e => e.ID == id);
        }
    }
}
