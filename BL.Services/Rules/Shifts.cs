﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;

namespace BL.Services.Rules
{
    class Shifts : IShifts
    {

        public bool IsShiftValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            // If there are currently no shifts then this proposal is valid
            if (shifts.Count(x => x.Engineer != null) == 0)
            {
                return true;
            }
            else if (shiftId % 2 == 1)
            {
                //Its an afternoon shift, so check the morning is not the same enginner
                if (shifts[shiftId - 1].Engineer?.ID == candidateId)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                //Proposed shift is for a morning, we only check when populating the afternoon shift
                return true;
            }
        }
    }

  
}
