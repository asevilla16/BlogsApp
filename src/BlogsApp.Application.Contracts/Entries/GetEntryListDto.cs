﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BlogsApp.Entries
{
    public class GetEntryListDto : PagedAndSortedResultRequestDto 
    {
        public string? Filter {  get; set; }
    }
}
