using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

using TestBalticSoft.Interfaces;
using TestBalticSoft.Enumerations;

namespace TestBalticSoft
{
    public class Order : IOrder
    {

        int id;

        EnumTypeOrder orderType;

        DateTime _dtOrder;
        int _DocumentID;
        double Sum;
        int _State;

        int _idParent;

        public Order()
        {
            id = 0;
            _State = 0;
        }

        public Order(DateTime dtOrder, int docId, EnumTypeOrder t)
        {
            this._dtOrder = dtOrder;
            this._DocumentID = docId;
            this.orderType = t;
            _State = 0;
            id = 0;
        }

        public DateTime DateOrder
        {
            get
            {
                return _dtOrder;
            }

            set
            {
                _dtOrder = value;
            }
        }

        public int DocumentID
        {
            get
            {
                return _DocumentID;
            }

            set
            {
                _DocumentID = value;
            }
        }

        public int OrderID
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

        public int OrderState
        {
            get
            {
                return _State;
            }

            set
            {
                _State = value;
            }
        }

        public double OrderSum
        {
            get
            {
                return Sum;
            }

            set
            {
                Sum = value;
            }
        }

        public EnumTypeOrder TypeOrder
        {
            get
            {
                return orderType;
            }

            set
            {
                orderType = value;
            }
        }

        public int idParent
        {
            get
            {
                return _idParent;
            }

            set
            {
                _idParent = value;
            }
        }
    }
}
