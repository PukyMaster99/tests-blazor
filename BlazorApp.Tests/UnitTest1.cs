using Xunit;

namespace BlazorApp.Tests;

public class UnitTest1
{
    [Fact]
    public void SimpleTest_ShouldPass()
    {
        Assert.True(true);
    }

    [Fact]
    public void MathTest_ShouldPass()
    {
        var result = 2 + 2;
        Assert.Equal(4, result);
    }
}