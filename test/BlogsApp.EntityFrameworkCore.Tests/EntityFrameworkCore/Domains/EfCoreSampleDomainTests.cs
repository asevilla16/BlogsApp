using BlogsApp.Samples;
using Xunit;

namespace BlogsApp.EntityFrameworkCore.Domains;

[Collection(BlogsAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BlogsAppEntityFrameworkCoreTestModule>
{

}
