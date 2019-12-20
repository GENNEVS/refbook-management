using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefBookMS
{
    class Deposit
    {
        public int DepositNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime OpenedAt { get; set; }
        public double Amount { get; set; }

        public string GetDepositNumber()
        {
            return DepositNumber.ToString().PadLeft(6, '0');
        }

        internal string GetFirstName()
        {
            return FirstName;
        }

        internal string GetLastName()
        {
            return LastName;
        }

        internal string GetOpeningDate()
        {
            return OpenedAt.ToString("dd.MM.yyyy");
        }

        internal string GetBalance()
        {
            return Amount.ToString();
        }
    }
}
