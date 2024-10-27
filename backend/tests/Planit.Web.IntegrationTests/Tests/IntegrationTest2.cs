namespace Planit.Web.IntegrationTests.Tests;

public class IntegrationTest2 : BaseIntegrationTest
{
    public IntegrationTest2(CustomWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public void Test3()
    {
        Assert.True(true);
    }

    [Fact]
    public void Test4()
    {
        Assert.True(true);
    }
}