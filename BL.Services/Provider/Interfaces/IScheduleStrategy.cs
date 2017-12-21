using System.Collections.Generic;
using DAL.DataContext;

namespace BL.Services.Provider.Interfaces
{
    /// <summary>
    /// Provides a strategy for schedule generation
    /// </summary>
    public interface IScheduleStrategy
    {
        /// <summary>
        /// Generate the schedule using this strategy and given the specified parameters
        /// </summary>
        /// <param name="engineerPool">The pool to select engineers from</param>
        /// <param name="shiftsPerPeriod">The number of shifts to populate</param>
        /// <returns>Ordered list of shifts</returns>
        List<Shift> Generate(IEngineerPool engineerPool, int shiftsPerPeriod);
    }
}
