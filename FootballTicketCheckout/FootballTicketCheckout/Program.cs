using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTicketCheckout
{
    class Program
    {
        static readonly int INT_PREMIUM_TICKET = 75;
        static readonly int INT_GENERAL_TICKET = 50;
        static readonly Decimal DEC_SALES_TAX = .0875m;
        static void Main(string[] args)
        {
            String strPremiumInput, strGeneralInput;
            int intPremiumTotal, intGeneralTotal;

            bool valid = false;

            do
            {
                Console.WriteLine("Enter the number of premium tickets you want: ");
                strPremiumInput = Console.ReadLine();
                Console.WriteLine("Enter the number of general admission tickets you want: ");
                strGeneralInput = Console.ReadLine();

                valid = ValidateInput(strPremiumInput, strGeneralInput);
            } while (!valid);

            intPremiumTotal = Convert.ToInt32(strPremiumInput);
            intGeneralTotal = Convert.ToInt32(strGeneralInput);

            Decimal decimalSubTotal = intPremiumTotal * INT_PREMIUM_TICKET + intGeneralTotal * INT_GENERAL_TICKET;
            Decimal decimalSalesTax = decimalSubTotal * DEC_SALES_TAX;
            Decimal decimalGrandTotal = decimalSalesTax + decimalSubTotal;
            Decimal decimalPremiumPercentage = Decimal.Round(100 * intPremiumTotal / (intPremiumTotal + intGeneralTotal));

            int intPremiumPercentage = Convert.ToInt32(decimalPremiumPercentage);

            Console.WriteLine("Total Tickets: " + (intPremiumTotal + intGeneralTotal));
            Console.WriteLine("Premium Subtotal: $" + (intPremiumTotal * INT_PREMIUM_TICKET).ToString("F"));
            Console.WriteLine("General Admission Subtotal: $" + (intGeneralTotal * INT_GENERAL_TICKET).ToString("F"));
            Console.WriteLine("Subtotal: $" + decimalSubTotal.ToString("F"));
            Console.WriteLine("Sales Tax: $" + (decimalSubTotal * DEC_SALES_TAX).ToString("F"));
            Console.WriteLine("Grand Total: $" + decimalGrandTotal.ToString("F"));
            Console.WriteLine("Premium Percentage: " + intPremiumPercentage + "%");

            Console.ReadLine();

        }

        private static bool ValidateInput(String strInput1, String strInput2)
        {
            try
            {
                int intPositiveWhole1 = Convert.ToInt32(strInput1);
                int intPositiveWhole2 = Convert.ToInt32(strInput2);
                if (intPositiveWhole1 == 0 && intPositiveWhole2 == 0)
                {
                    return false;
                }
                else if (intPositiveWhole1 < 0 || intPositiveWhole2 < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                
                return false;
            }
        }
    }
}
