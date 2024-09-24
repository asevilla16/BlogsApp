using BlogsApp.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BlogsApp.Entries
{
    public class EntryDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }

        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
