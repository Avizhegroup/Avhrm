namespace Avhrm.Application.Client.Features;
public class ApiResponse
{
    public bool Successful { get; set; }
    public object Value { get; set; }
}

public class ApiResponse<T>
{
    public bool Successful { get; set; }
    public T Value { get; set; }
}
