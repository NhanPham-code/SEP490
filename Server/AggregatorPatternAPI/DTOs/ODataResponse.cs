namespace AggregatorPatternAPI.DTOs;

public class ODataResponse<T>
{
    public List<T> Value { get; set; }
}