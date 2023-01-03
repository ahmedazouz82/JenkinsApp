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
    public class DetailsModel : PageModel
    {
        private readonly Archiver.Data.ArchiverContext _context;

        public DetailsModel(Archiver.Data.ArchiverContext context)
        {
            _context = context;
        }

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
    }
}
