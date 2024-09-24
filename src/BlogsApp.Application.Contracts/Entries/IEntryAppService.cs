using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BlogsApp.Entries
{
    public interface IEntryAppService : IApplicationService
    {
        Task<PagedResultDto<EntryDto>> GetListAsync(GetEntryListDto input);
        Task<EntryDto> GetAsync(Guid id);
        Task<EntryDto> CreateAsync(CreateUpdateEntryDto entryDto);
        Task DeleteAsync(Guid id);
        Task<EntryDto> UpdateAsync(Guid id, CreateUpdateEntryDto input);
    }
}
