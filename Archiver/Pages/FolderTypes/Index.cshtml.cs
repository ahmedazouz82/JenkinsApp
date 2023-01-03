using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Archiver.Data;
using Archiver.Models;

namespace Archiver.Pages.FolderTypes
{
    public class IndexModel : PageModel
    {
        private readonly Archiver.Data.ArchiverContext _context;

        public IndexModel(Archiver.Data.ArchiverContext context)
        {
            _context = context;
        }

        public IList<DocFoldersType> DocFoldersType { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? listtypenameDDL { get; set; }
  
        public string? TypeGenreString { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ -------------------------------------------
            IQueryable<string> genreQuery = from m in _context.DocFoldersType
                                            orderby m.TypeGenre
                                            select m.TypeGenre;

            var mylist = from m in _context.DocFoldersType
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                mylist = mylist.Where(s => s.TypeName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(TypeGenreString))
            {
                mylist = mylist.Where(x => x.TypeGenre.Contains(TypeGenreString)); // test
            }

            listtypenameDDL = new SelectList(await genreQuery.Distinct().ToListAsync());
            DocFoldersType = await mylist.ToListAsync();


            // pure list without search .-------------------------------------------
            //if (_context.DocFoldersType != null)
            //{
            //    DocFoldersType = await _context.DocFoldersType.ToListAsync();
            //}


            // list search ability .-------------------------------------------
            //var searchlist = from m in _context.DocFoldersType
            //             select m;
            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    searchlist = searchlist.Where(s => s.TypeName.Contains(SearchString));
            //}

            //DocFoldersType = await searchlist.ToListAsync();
        }
    }
}
