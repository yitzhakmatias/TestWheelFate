using System.Collections.Generic;
using BL.Services.Provider.Interfaces;
using DAL.DataContext;

namespace BL.Services.Provider
{
    /// <summary>
    /// TODO could replace this with a Decorator class for IRule
    /// </summary>
    public class RuleEvaluator : IRuleEvaluator
    {
        private readonly IList<IRule> _rules;

        public RuleEvaluator(IList<IRule> rules)
        {
            _rules = rules;
        }

        public bool IsValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            var valid = true;
            // Check if all the rules pass
            foreach (var rule in _rules)
            {
                valid &= rule.IsValid(shiftId, candidateId, shifts);
            }

            return valid;
        }
    }
}
