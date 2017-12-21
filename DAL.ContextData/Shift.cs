using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ContextData;

namespace DAL.DataContext
{
    public class Shift
    {
       

        public Shift(int i)
        {
            this.Id = i;
        }

        public int Id { get; set; }

        public Engineer Engineer { get; set; }

    }
}
