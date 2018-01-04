using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class Shift
    {
       

        public Shift(int i)
        {
            this.ShiftId = i;
        }

        public int ShiftId { get; set; }


        public virtual ICollection<TaskEngineer> Tasks { get; set; }

    }
}
