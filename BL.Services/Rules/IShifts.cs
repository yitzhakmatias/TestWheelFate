using System.Collections.Generic;
using DAL.DataContext;

namespace BL.Services.Rules
{
    public interface IShifts
    {
        bool IsShiftValid(int shiftId, int candidateId, List<Shift> shifts);
    }
}