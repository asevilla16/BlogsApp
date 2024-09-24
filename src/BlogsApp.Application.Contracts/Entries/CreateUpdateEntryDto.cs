using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApp.Entries
{
    public class CreateUpdateEntryDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Required]
        public Guid CategoryId { get; set; } = Guid.Empty;
    }
}
