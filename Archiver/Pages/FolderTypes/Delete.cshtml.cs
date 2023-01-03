using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Archiver.Data;
using Archiver.Models;

namespace Archiver.Pages.FolderTypes
{
    public class DeleteModel : PageModel
    {
        private readonly Archiver.Data.ArchiverContext _context;

        public DeleteModel(Archiver.Data.ArchiverContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DocFoldersType DocFoldersType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DocFoldersType == null)
            {
                return NotFound();
            }

            var docfolderstype = await _context.DocFoldersType.FirstOrDefaultAsync(m => m.ID == id);

            if (docfolderstype == null)
            {
                return NotFound();
            }
            else 
            {
                DocFoldersType = docfolderstype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DocFoldersType == null)
            {
                return NotFound();
            }
            var docfolderstype = await _context.DocFoldersType.FindAsync(id);

            if (docfolderstype != null)
            {
                DocFoldersType = docfolderstype;
                _context.DocFoldersType.Remove(DocFoldersType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
