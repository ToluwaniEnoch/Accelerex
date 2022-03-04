using System.Collections;
using System.Text;
using System.Text.Json;
using Accelerex.Api.Entities;
using Accelerex.Api.Interfaces;
using DayOfWeek = System.DayOfWeek;
using Type = Accelerex.Api.Entities.Type;

namespace Accelerex.Api.Services;

public class ConverterService : IConverterService
{
    public string ConvertToReadableText(WeekDays payload)
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

    public int[] InversePermutate(int[] payload)
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