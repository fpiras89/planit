namespace Planit.Web.IntegrationTests.Tests;

public class IntegrationTest1 : BaseIntegrationTest
{
    public IntegrationTest1(CustomWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }

    [Fact]
    public void Test2()
    {
        Assert.True(true);
    }
}