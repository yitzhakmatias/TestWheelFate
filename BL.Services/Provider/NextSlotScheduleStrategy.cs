using System.Collections.Generic;
using BL.Services.Provider.Interfaces;
using DAL.DataContext;

namespace BL.Services.Provider
{
    /// <summary>
    /// Rather than trying to find the best candidate for a fixed slot, this algorithm
    /// picks a random engineer then walks through the slots that havn't been filled to look
    /// for a suitable one.
    /// </summary>
    public class NextSlotScheduleStrategy : IScheduleStrategy
    {
        private readonly IRuleEvaluator _ruleEvaluator;

        public NextSlotScheduleStrategy(IRuleEvaluator ruleEvaluator)
        {
            _ruleEvaluator = ruleEvaluator;
        }

        public List<Shift> Generate(IEngineerPool engineerPool, int shiftsPerPeriod)
        {
            // Populate the shift schedule without engineers
            var shifts = new List<Shift>(shiftsPerPeriod);
            for(var i = 0; i < shiftsPerPeriod; i++)
            {
                shifts.Add(new Shift(i));
            }

            // Find an engineer and then walk through the shifts to 
            // find the next valid one
            Engineer candidate;
            while((candidate = engineerPool.PullRandom()) != null)
            {
                for (int i = 0; i < shiftsPerPeriod; i++)
                {
                    if (shifts[i].Engineer == null)
                    {
                        var foundSuitableSlot = _ruleEvaluator.IsValid(i, candidate.ID, shifts);
                        if (foundSuitableSlot)
                        {
                            shifts[i].Engineer = candidate;
                            engineerPool.Remove(candidate);
                            break;
                        }
                    }
                }
            }

            return shifts;
        }
    }
}
