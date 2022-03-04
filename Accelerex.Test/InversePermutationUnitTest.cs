using Accelerex.Api.Controllers;
using Accelerex.Api.Services;
using Xunit;

namespace Accelerex.Test;

public class InversePermutationUnitTest
{

    [Fact]
    public void InvertArrayOfLengthFour()
    {
        int[] payload = new[] {1, 4, 3, 2};
        int[] expected = new[] {1, 4, 3, 2};

        var controller = new ConverterController(new ConverterService());
        var actionResult = controller.Invert(payload);
        Assert.Equal(expected, actionResult.Value);
    }
    
    [Fact]
    public void InvertArrayOfLengthFive()
    {
        int[] payload = new[] {2, 3, 4, 5, 1};
        int[] expected = new[] {5, 1, 2, 3, 4};

        var controller = new ConverterController(new ConverterService());
        var actionResult = controller.Invert(payload);
        Assert.Equal(expected, actionResult.Value);
    }
    
}