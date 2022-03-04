using Accelerex.Api.Entities;
using MediatR;
using Type = Accelerex.Api.Entities.Type;

namespace Accelerex.Api.Handler;

public class ConverterHandler : IRequestHandler<ConvertWeekdays, string>
{

    public ConverterHandler()
    {
    }
    public async Task<string> Handle(ConvertWeekdays request, CancellationToken cancellationToken = default)
    {
        return await ConvertToReadableText(request.WeekDays);
        
    }
    
    private async Task<string> ConvertToReadableText(WeekDays payload)
    {
        var receivedInfo = payload;
        var result = "";

        var previousDay = payload.Days.First();
        var previousDayKey = previousDay.Key;
        foreach (var day in payload.Days)
        {
            var dayOfWeek = day.Key;
            
            if (day.Value.Count > 0)
            {
                if (day.Value[0].Type.ToLower() == Type.Close.ToString().ToLower())
                {
                    if (previousDay.Value.Count > 0)
                    {
                        var toTime = ConvertToTime(day.Value[0].Value);
                        
                        result = result.TrimEnd('\r', '\n');

                        result += $"- {toTime} \n";

                    }
                    

                    day.Value.RemoveAt(0);
                }

                result += $"{dayOfWeek.ToUpper()}: ";
                foreach (var info in day.Value)
                {
                    var type = info.Type;
                    var time = ConvertToTime(info.Value);

                    if (info.Type.ToLower() == Type.Close.ToString().ToLower())
                    {
                        result += $"- {time}, ";
                    }
                    else
                    {
                        result += $" {time} ";

                    }
                    
                }
                

                result = result.TrimEnd(',', ' ');
                result += " \n";
                previousDay = day;
            }
            else
            {
                previousDay = day;
                result += $"{dayOfWeek.ToUpper()} : Closed \n";
            }

        }

        return result;
    }
    
    private string ConvertToTime(int linuxTime)
    {
        var timeResult = "";
        var time = (linuxTime / 60) / 60;
        if (time > 12)
        {
            time = time - 12;
            return $"{time} PM";
        }
        return $"{time} AM";

    }
}