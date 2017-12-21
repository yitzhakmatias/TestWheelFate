using System.Collections.Generic;
using DAL.DataContext;

namespace BL.Services.Provider.Interfaces
{
    /// <summary>
    /// Provides a mechanism for checking if multiple rules are valid
    /// TODO: replace with decorator?
    /// </summary>
    public interface IRuleEvaluator
    {
        /// <summary>
        /// Determines if the rule is valid given the passed parameters
        /// </summary>
        /// <param name="shiftId">Identifier of the proposed shift</param>
        /// <param name="candidateId">Identifier of the proposed candiate</param>
        /// <param name="shifts">Curent schedule to shifts</param>
        /// <returns>True if rule passed against passed criteria</returns>
        bool IsValid(int shiftId, int candidateId, List<Shift> shifts);
    }
}
