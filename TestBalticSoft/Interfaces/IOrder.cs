using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using TestBalticSoft.Enumerations;

namespace TestBalticSoft.Interfaces
{
    public interface IOrder
    {
        [Key]
        int OrderID { get; set; }

        int DocumentID { get; set; }

        DateTime DateOrder { get; set; }

        double OrderSum { get; set; }

        int OrderState { get; set; }
        
        EnumTypeOrder TypeOrder { get; set; }

        int idParent { get; set; }

        

    }
}
