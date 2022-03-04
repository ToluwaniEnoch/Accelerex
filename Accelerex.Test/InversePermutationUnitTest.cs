using System.Threading;
using Accelerex.Api.Controllers;
using Accelerex.Api.Entities;
using Accelerex.Api.Handler;
using Accelerex.Api.Services;
using MediatR;
using Xunit;

namespace Accelerex.Test;

public class InversePermutationUnitTest
{

    [Fact]
    public async void InvertArrayOfLengthFour()
    {
        int[] payload = new[] {1, 4, 3, 2};
        int[] expected = new[] {1, 4, 3, 2};

        var handler = new InversePermuteHandler();
        var result = await handler.Handle(new InversePermute(payload), CancellationToken.None);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public async void InvertArrayOfLengthFive()
    {
        int[] payload = new[] {2, 3, 4, 5, 1};
        int[] expected = new[] {5, 1, 2, 3, 4};

        var handler = new InversePermuteHandler();
        var result = await handler.Handle(new InversePermute(payload), CancellationToken.None);
        Assert.Equal(expected, result);
    }
    
}