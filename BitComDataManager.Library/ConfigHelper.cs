using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitComDataManager.Library
{
    public class ConfigHelper
    {
        public static decimal GetTexRate()
        {
            decimal output = 0;

            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Decimal.TryParse(rateText, out output);

            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The tax rate is not set properly");
            }

            return output;
        }
    }
}
