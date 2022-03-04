using Accelerex.Api.Entities;

namespace Accelerex.Api.Interfaces;

public interface IConverterService
{
    string ConvertToReadableText(WeekDays payload);
    int[] InversePermutate(int[] payload);
}