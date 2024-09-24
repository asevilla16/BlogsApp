using System.Threading.Tasks;

namespace BlogsApp.Data;

public interface IBlogsAppDbSchemaMigrator
{
    Task MigrateAsync();
}
