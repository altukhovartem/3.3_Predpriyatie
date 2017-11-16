using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        string inn = string.Empty;

        public readonly Guid Guid;
        public string Name { get; set; }
        public DateTime EstablishDate { get; set; }


        public string Inn
        {
            get => inn;
            set
            {
                if (value.Length != 10 || !value.All(char.IsDigit))
                    throw new ArgumentException();
                inn = value;
            }
        }

        public TimeSpan ActiveTimeSpan { get => DateTime.Now - EstablishDate; }


        public Enterprise()
        {
            Guid = Guid.NewGuid();
        }

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == Guid))
                amount += t.Amount;
            return amount;
        }
    }
}
