using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;

namespace BL.Services.Rules
{
    public class ConsecutiveDays : IConsecutiveDays
    {
        public bool IsValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            // If shiftId is the first day then allocation must be valid
            if (shiftId < 2)
            {
                return true;
            }
            else
            {
                bool isMorning = shiftId == 0 || shiftId % 2 == 0;
                if (isMorning)
                {
                    //Proposed shift is for a morning - check the last 2 shifts are not for the same enginner
                    if (shifts[shiftId - 1].Engineer?.ID == candidateId ||
                        shifts[shiftId - 2].Engineer?.ID == candidateId)
                    {
                        return false;
                    }
                }
                else
                {
                    //Proposd shift is for an afternoon - check the previous days shifts
                    if (shifts[shiftId - 2].Engineer?.ID == candidateId ||
                        shifts[shiftId - 3].Engineer?.ID == candidateId)
                    {
                        return false;
                    }
                }

                // The same enginner is not defined for the previous day, so the proposal is valid
                return true;
            }
        }
    }
}
