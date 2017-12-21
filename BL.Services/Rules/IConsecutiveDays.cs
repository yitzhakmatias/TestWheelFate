using System.Collections.Generic;
using DAL.DataContext;

namespace BL.Services.Rules
{
    public interface IConsecutiveDays
    {
        bool IsValid(int shiftId, int candidateId, List<Shift> shifts);
    }
}