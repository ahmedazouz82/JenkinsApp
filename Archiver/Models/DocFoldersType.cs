using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archiver.Models
{
    public class DocFoldersType
    {
        public int ID { get; set; }

        [Display(Name = "أنواع المجلدات")]
        public string TypeName { get; set; } = string.Empty;

        public string TypeGenre { get; set; } = string.Empty;
        
    }
}
