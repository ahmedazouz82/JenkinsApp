using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Archiver.Models
{
    public class Users
    {
        public int UserID { get; set; }

        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; } = string.Empty;

        public string UserPassword { get; set; } = string.Empty;
    }
}
