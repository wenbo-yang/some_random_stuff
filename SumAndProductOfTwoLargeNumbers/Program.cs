using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAndProductOfTwoLargeNumbers
{
    class Program
    {
        string Sum(string str1, string str2)
        {
            // Before proceeding further, make sure length
            // of str2 is larger.
            if (str1.Length > str2.Length)
            {
                var temp = str1;
                str1 = str2;
                str2 = temp;
            }

            // Take an empty string for storing result
            var resultString = new List<char>();

            // Calculate lenght of both string
            int n1 = str1.Length, n2 = str2.Length;

            int carry = 0;
            for (int i = n1; i >= 0; i--)
            {
                // Do school mathematics, compute sum of
                // current digits and carry
                int sum = ((str1[i] - '0') + (str2[i] - '0') + carry);
                resultString.Add(sum >= 10 ? (sum - 10).ToString()[0] : sum.ToString()[0]);

                // Calculate carry for next step
                carry = sum >= 10 ? 1 : 0;
            }

            // Add remaining digits of larger number
            for (int i = n2; i > n1; i--)
            {
                int sum = ((str2[i] - '0') + carry);
                resultString.Add(sum >= 10 ? (sum - 10).ToString()[0] : sum.ToString()[0]);
                carry = sum >= 10 ? 1 : 0;
            }

            // Add remaining carry
            if (carry == 1)
            {
                resultString.Add(carry.ToString()[0]);
            }

            resultString.Reverse();
            return new string(resultString.ToArray());
        }

        string Multiply(string num1, string num2)
        {
            int n1 = num1.Length;
            int n2 = num2.Length;
            if (n1 == 0 || n2 == 0)
            {
                return "";
            }
            

            // will keep the result number in vector
            // in reverse order
            var result = new List<int>();

            // Below two indexes are used to find positions
            // in result. 
            int i_n1 = 0;
            int i_n2 = 0;

            int i = 0;
            // Go from right to left in num1
            for (i = n1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1_i = num1[i] - '0';

                // To shift position to left after every
                // multiplication of a digit in num2
                i_n2 = 0;

                // Go from right to left in num2             
                for (int j = n2 - 1; j >= 0; j--)
                {
                    // Take current digit of second number
                    int n2_i = num2[j] - '0';

                    // Multiply with current digit of first number
                    // and add result to previously stored result
                    // at current position. 
                    int sum = n1_i * n2_i + result[i_n1 + i_n2] + carry;

                    // Carry for next iteration
                    carry = sum / 10;

                    // Store result
                    result[i_n1 + i_n2] = sum % 10;

                    i_n2++;
                }

                // store carry in next cell
                if (carry > 0)
                    result[i_n1 + i_n2] += carry;

                // To shift position to left after every
                // multiplication of a digit in num1.
                i_n1++;
            }

            // ignore '0's from the right
            i = result.Count- 1;
            while (i >= 0 && result[i] == 0)
                i--;

            // If all were '0's - means either both or
            // one of num1 or num2 were '0'
            if (i == -1)
                return "0";

            // generate the result string
            string s = "";
            while (i >= 0)
                s += result[i--].ToString();

            return s;
        }

        static void Main(string[] args)
        {
        }
    }
}
