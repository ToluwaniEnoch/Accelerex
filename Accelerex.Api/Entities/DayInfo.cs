namespace Accelerex.Api.Entities;

public class TypeValue
{
    public String Type { get; set; }
    public int Value { get; set; }
}


public enum Type
{
    Open, Close
}