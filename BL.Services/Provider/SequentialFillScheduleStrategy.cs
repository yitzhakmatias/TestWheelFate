using System.Collections.Generic;
using BL.Services.Provider.Interfaces;
using DAL.ContextData;
using DAL.DataContext;

namespace SupportWheel.BusinessImplementations.Services
{
    /// <summary>
    /// Attemp to fill the schedule a slot at a time. For each slot, pick an engineer at random and
    /// check it is valid. If so fill the slot and move to the next one. If not, pick a different engineer
    /// at random from the pool and try that one.
    /// </summary>
    public class SequentialFillScheduleStrategy : IScheduleStrategy
    {
        private IRuleEvaluator _ruleEvaluator;

        public SequentialFillScheduleStrategy(IRuleEvaluator ruleEvaluator)
        {
            _ruleEvaluator = ruleEvaluator;
        }

        public List<Shift> Generate(IEngineerPool engineerPool, int shiftsPerPeriod)
        {
            var shifts = new List<Shift>();

            // Walk throught the shift slots and find a valid engineer for this slot
            for (int i = 0; i < shiftsPerPeriod; i++)
            {
                bool foundSuitableCandiate = false;

                Engineer candidate;
                while (!foundSuitableCandiate && ((candidate = engineerPool.PullRandom()) != null))
                {
                    foundSuitableCandiate = _ruleEvaluator.IsValid(i, candidate.ID, shifts);
                    if (foundSuitableCandiate)
                    {
                        shifts.Add(new Shift(i) { Engineer = candidate });
                        engineerPool.Remove(candidate);
                        engineerPool.ResetPullables();
                    }
                }
            }
            return shifts;
        }
    }
}
