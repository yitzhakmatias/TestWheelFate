namespace BL.Services.Provider.Interfaces
{
    /// <summary>
    /// Adapts the Random number generator class
    /// </summary>
    public interface IRandomAdapter
    {
        int Next(int max);
    }
}
