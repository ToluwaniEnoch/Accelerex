using Accelerex.Api.Entities;
using Accelerex.Api.Interfaces;
using MediatR;

namespace Accelerex.Api.Handler;

public class InversePermuteHandler : IRequestHandler<InversePermute, int[]>
{

    public InversePermuteHandler()
    {
    }
    public async Task<int[]> Handle(InversePermute request, CancellationToken cancellationToken)
    {
        return await InversePermutate(request.payload);
    }
    
    private async Task<int[]> InversePermutate(int[] payload)
    {
        var size = payload.Length;
        int[] secondList = new int[size];

        for (int i = 0; i < size ; i++ )
        {
            var index = i;
            var number = payload[i];
            
            
            secondList[number - 1] = i + 1;
        }

        return secondList;
    }
}