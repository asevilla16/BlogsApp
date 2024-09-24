using Xunit;

namespace BlogsApp.EntityFrameworkCore;

[CollectionDefinition(BlogsAppTestConsts.CollectionDefinitionName)]
public class BlogsAppEntityFrameworkCoreCollection : ICollectionFixture<BlogsAppEntityFrameworkCoreFixture>
{

}
