using BlogsApp.Samples;
using Xunit;

namespace BlogsApp.EntityFrameworkCore.Applications;

[Collection(BlogsAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BlogsAppEntityFrameworkCoreTestModule>
{

}
