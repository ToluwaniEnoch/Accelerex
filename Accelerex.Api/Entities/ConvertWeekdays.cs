using MediatR;

namespace Accelerex.Api.Entities;

public record ConvertWeekdays(WeekDays WeekDays): IRequest<string>;