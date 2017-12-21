using System.Collections.Generic;
using DAL.DataContext;

namespace BL.Services.Provider.Interfaces
{
    /// <summary>
    /// Provides a mechanism for creation of a schedule
    /// </summary>
    public interface IScheduleGeneratorService
    {
        /// <summary>
        /// Generates a new schedule with the specificed parameters
        /// </summary>
        /// <param name="shiftsPerPeriod">The number of shifts per period</param>
        /// <param name="shiftsPerEngineerPerPeriod">The number of shifts per engineer per period</param>
        /// <returns>Ordered list of shifts</returns>
        List<Shift> Generate(int shiftsPerPeriod, int shiftsPerEngineerPerPeriod);
    }
}
