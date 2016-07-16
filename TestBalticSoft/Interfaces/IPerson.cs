using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBalticSoft.Interfaces;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace TestBalticSoft.Interfaces
{
    public interface IPerson
    {
        [Key]
        int PersonID { get; set; }


        List<IOrder> Orders { get; set; }

        string FIO { get; set; }

        string Address { get; set; }
    }
    
}
