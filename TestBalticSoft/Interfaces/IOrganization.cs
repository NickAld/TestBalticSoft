using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using TestBalticSoft.Interfaces;

namespace TestBalticSoft.Interfaces
{
    public interface IOrganization
    {
        [Key]
        int OrganizationID { get; set; }
        List<IOrder> Orders { get; set; }

        string INN { get; set; }

        string AddressFact { get; set; }

        string AddressReg { get; set; }

    }
}
