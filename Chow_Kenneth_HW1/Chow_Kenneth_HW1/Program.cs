using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Author: Kenneth Chow
//Date: September 6, 2016
//Assignment: Homework 1
//Description: This program calculates the total of buying premium and general admission tickets based on a fixed price. It also 
//outputs the percentage of premium tickets.
namespace Chow_Kenneth_HW1
{
    class Program
    {
        //instantiate global constants
        static readonly int INT_PREMIUM_TICKET = 75;
        static readonly int INT_GENERAL_TICKET = 50;
        static readonly Decimal DEC_SALES_TAX = .0875m;

        //main
        static void Main(string[] args)
        {
            //instantiates input variables, integer conversions to be used later, and a boolean variable for the while loop
            String strPremiumInput, strGeneralInput;
            int intPremiumTotal, intGeneralTotal;
            bool valid = false;

            //check validation, repeat until inputs are valid
            do
            {
                //gather inputs
                Console.WriteLine("Enter the number of premium tickets you want: ");
                strPremiumInput = Console.ReadLine();
                Console.WriteLine("Enter the number of general admission tickets you want: ");
                strGeneralInput = Console.ReadLine();
        
                //decides whether or not to continue the loop
                valid = ValidateInput(strPremiumInput, strGeneralInput);
            } while (!valid);

            //convert string inputs into integers
            intPremiumTotal = Convert.ToInt32(strPremiumInput);
            intGeneralTotal = Convert.ToInt32(strGeneralInput);

            //all the conversions to be used later
            Decimal decimalSubTotal = intPremiumTotal * INT_PREMIUM_TICKET + intGeneralTotal * INT_GENERAL_TICKET;
            Decimal decimalSalesTax = decimalSubTotal * DEC_SALES_TAX;
            Decimal decimalGrandTotal = decimalSalesTax + decimalSubTotal;
            Decimal decimalPremiumPercentage = Decimal.Round(100 * intPremiumTotal / (intPremiumTotal + intGeneralTotal));

            //premium percentage conversion
            int intPremiumPercentage = Convert.ToInt32(decimalPremiumPercentage);

            //required outputs
            Console.WriteLine("Total Tickets: " + (intPremiumTotal + intGeneralTotal));
            Console.WriteLine("Premium Subtotal: $" + (intPremiumTotal * INT_PREMIUM_TICKET).ToString("F"));
            Console.WriteLine("General Admission Subtotal: $" + (intGeneralTotal * INT_GENERAL_TICKET).ToString("F"));
            Console.WriteLine("Subtotal: $" + decimalSubTotal.ToString("F"));
            Console.WriteLine("Sales Tax: $" + (decimalSubTotal * DEC_SALES_TAX).ToString("F"));
            Console.WriteLine("Grand Total: $" + decimalGrandTotal.ToString("F"));
            Console.WriteLine("Premium Percentage: " + intPremiumPercentage + "%");

            Console.ReadLine();

        }

        //Validate Input takes in two strings and checks if they are valid based on requirements
        //returns true if valid
        //parameters: two strings to be validated
        private static bool ValidateInput(String strInput1, String strInput2)
        {
            bool boolReturn;
            //use try catch for if non numbers
            try
            {
                //converts to integers
                int intPositiveWhole1 = Convert.ToInt32(strInput1);
                int intPositiveWhole2 = Convert.ToInt32(strInput2);

                //checks if at least one is non-zero
                if (intPositiveWhole1 == 0 && intPositiveWhole2 == 0)
                {
                    boolReturn =  false;
                }

                //checks if they are both above 0
                else if (intPositiveWhole1 < 0 || intPositiveWhole2 < 0)
                {
                    boolReturn = false;
                }

                //returns true if criteria is met
                else
                {
                    boolReturn = true;
                }
            }
            //if there was an exception (from not being a number, return false
            catch
            {
                boolReturn = false;
            }
            if (boolReturn == false)
                Console.WriteLine("Error, please enter 2 positive whole numbers \n");

            return boolReturn;
        }
    }
}
