using BlogsApp.Categories;
using BlogsApp.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BlogsApp
{
    public class BlogsAppDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Entry, Guid> _entriesRepository;
        private readonly IRepository<Category, Guid> _categoriesRepository;

        public BlogsAppDataSeederContributor(IRepository<Entry, Guid> entriesRepository, IRepository<Category, Guid> categoriesRepository)
        {
            _entriesRepository = entriesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _entriesRepository.GetCountAsync() > 0)
            {
                return;
            }

            if (await _categoriesRepository.GetCountAsync() > 0)
            {
                return;
            }

            var programming = await _categoriesRepository.InsertAsync(
                new Category
                {
                    Name = "Programming",
                    Description = "Entries about programming languages or frameworks"
                }
            );

            var travel = await _categoriesRepository.InsertAsync(
                new Category
                {
                    Name = "Travel",
                    Description = "Entries related to traveling."
                }
            );

            await _entriesRepository.InsertAsync(
                new Entry
                {
                    Title = "Understanding Asynchronous Programming in JavaScript",
                    Content = "In modern web development, asynchronous programming is essential for handling time-consuming tasks such as network requests and file operations without blocking the main thread. In this post, we'll explore the basics of asynchronous programming, including callbacks, promises, and the async/await pattern in JavaScript.",
                    PublicationDate = new DateTime(1949, 6, 8),
                    CategoryId = programming.Id
                },
                autoSave: true
            );

            await _entriesRepository.InsertAsync(
                new Entry
                {
                    Title = "Top 5 Must-Visit Destinations in Japan",
                    Content = "Japan offers a unique blend of modern and traditional attractions that make it a must-visit destination. From the bustling streets of Tokyo to the serene temples of Kyoto, here are the top 5 places you must experience on your trip to Japan.",
                    PublicationDate = new DateTime(1995, 9, 27),
                    CategoryId = travel.Id
                },
                autoSave: true
            );
        }

    }
}
