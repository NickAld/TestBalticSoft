using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

using TestBalticSoft.Interfaces;

namespace TestBalticSoft
{
    public class Organization : IOrganization
    {
        int id;

        string _AddressFact;
        string _AddressReg;
        string _INN;

        List<IOrder> _orders;

        public Organization()
        {

        }

        /// <summary>
        /// Огранизация
        /// </summary>
        /// <param name="AddF">Фактические адрес доставки</param>
        /// <param name="AddReg">Адрес регистрации организации</param>
        /// <param name="OrgINN">ИНН организации</param>

        public Organization(string AddF, string AddReg, string OrgINN)
        {
            this._AddressFact = AddF;
            this._AddressReg = AddReg;
            this._INN = OrgINN;
            id = 0;
        }

        [Display(Name = "Адрес фактический")]

        public string AddressFact
        {
            get
            {
                return _AddressFact;
            }

            set
            {
                _AddressFact = value;
            }
        }
        [Display(Name = "Адрес регистрации")]
        public string AddressReg
        {
            get
            {
                return _AddressReg;
            }

            set
            {
                _AddressReg = value;
            }
        }

        [Display(Name = "ИНН организации")]
        public string INN
        {
            get
            {
                return _INN;
            }

            set
            {
                _INN = value;
            }
        }

        public List<IOrder> Orders
        {
            get
            {
                return _orders;
            }

            set
            {
                _orders = value;
            }
        }

        public int OrganizationID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
