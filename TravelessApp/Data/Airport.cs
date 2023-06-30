namespace TravelessApp.Data;

public class Airport
{
    public string Code { get; }
    
    public string FullName { get; }

    public Airport(string code, string fullName)
    {
        Code = code;
        FullName = fullName;
    }
}