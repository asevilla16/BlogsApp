using BlogsApp.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace BlogsApp.Entries
{
    public class EntryAppService : ApplicationService, IEntryAppService
    {

        private readonly IRepository<Entry, Guid> _blogEntryRepository;
        private readonly IRepository<Category, Guid> _categoriesRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly ICurrentUser _currentUser;

        public EntryAppService(
            IRepository<Entry, Guid> blogEntryRepository, 
            IRepository<Category, Guid> categoriesRepository,
            IRepository<IdentityUser, Guid> userRepository,
        ICurrentUser currentUser)
        {
            _blogEntryRepository = blogEntryRepository;
            _categoriesRepository = categoriesRepository;
            _userRepository = userRepository;
            _currentUser = currentUser;
        }
        public async Task<EntryDto> CreateAsync(CreateUpdateEntryDto entryDto)
        {
            var blogEntry = await _blogEntryRepository.InsertAsync(
                new Entry
                {
                    Title = entryDto.Title,
                    Content = entryDto.Content,
                    PublicationDate = entryDto.PublicationDate,
                    AuthorId = _currentUser.Id.Value,
                    CategoryId = entryDto.CategoryId
                }
            );

            return new EntryDto { Title = blogEntry.Title, Content = blogEntry.Content, AuthorId = blogEntry.AuthorId, CategoryId = blogEntry.CategoryId };
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<EntryDto>> GetListAsync(GetEntryListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Entry.Title);
            }

            var categories = await _categoriesRepository.GetListAsync();

            var entries = await _blogEntryRepository.GetListAsync(item =>item.Title.Contains(input.Filter ?? ""));
            var entriesDto = new List<EntryDto>();

            var users = await _userRepository.GetListAsync();

            

            entries.ForEach(x => {
                var category = categories.Where(cat => cat.Id == x.CategoryId).FirstOrDefault();

                var user = users.Where (u => u.Id == x.AuthorId).FirstOrDefault();

                entriesDto.Add(new EntryDto
                {
                    Title = x.Title,
                    Content = x.Content,
                    PublicationDate = x.PublicationDate,
                    AuthorId = x.AuthorId,
                    AuthorName = user.UserName ?? "",
                    CategoryId = x.CategoryId,
                    CategoryName = category.Name ?? ""

                });
                
            });

            var totalCount = input.Filter == null
                ? await _blogEntryRepository.CountAsync()
                : await _blogEntryRepository.CountAsync(
                    author => author.Title.Contains(input.Filter));

            return new PagedResultDto<EntryDto>(
                totalCount,
                entriesDto
            );
        }

        public async Task<EntryDto> GetAsync(Guid id) 
        { 
            var blogEntry = await _blogEntryRepository.GetAsync( id );

            return ObjectMapper.Map<Entry, EntryDto>(blogEntry);
        }

        public async Task<EntryDto> UpdateAsync(Guid guid, CreateUpdateEntryDto entryDto)
        {
            var entry = await _blogEntryRepository.GetAsync(guid);

            entry.Title = entryDto.Title;
            entry.Content = entryDto.Content;
            entry.PublicationDate = entryDto.PublicationDate;
            entry.CategoryId = entryDto.CategoryId;

            await _blogEntryRepository.UpdateAsync(entry);
            return ObjectMapper.Map<Entry, EntryDto>(entry);
        }
    }
}
