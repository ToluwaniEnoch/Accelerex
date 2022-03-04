using Accelerex.Api.Entities;

namespace Accelerex.Api.Interfaces;

public interface IConverterService
{
    Task<string> ConvertToReadableText(WeekDays payload);
    Task<int[]> InversePermutate(int[] payload);
}