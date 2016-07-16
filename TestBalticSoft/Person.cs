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
    public class Person : IPerson
    {
        int id;

        string _FIO;
        string _Address;

        List<IOrder> _orders;

        public Person()
        {

        }

        /// <summary>
        /// Частное лицо
        /// </summary>
        /// <param name="Name">ФИО частного лица</param>
        /// <param name="Addr">Адрес доставки</param>
        public Person(string Name, string Addr)
        {
            this._Address = Addr;
            this._FIO = Name;
            id = 0;
        }
        [Display(Name ="Адрес")]
        public string Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = value;
            }
        }

        [Display(Name = "ФИО клиента")]
        public string FIO
        {
            get
            {
                return _FIO;
            }

            set
            {
                _FIO = value;
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

        public int PersonID
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
