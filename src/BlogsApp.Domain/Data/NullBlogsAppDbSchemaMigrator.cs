using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlogsApp.Data;

/* This is used if database provider does't define
 * IBlogsAppDbSchemaMigrator implementation.
 */
public class NullBlogsAppDbSchemaMigrator : IBlogsAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
