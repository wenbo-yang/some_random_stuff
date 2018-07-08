using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateDigitIntoWords
{
    class Program
    {
        public String numberToWords(int num)
        {
            String[] units = { "", " Thousand", " Million", " Billion" };
            int i = 0;
            String res = "";
            bool isNegative = num < 0;

            num = Math.Abs(num);
            
            while (num > 0)
            {
                int temp = num % 1000;
                if (temp > 0) res = Convert(temp) + units[i] + (res.Length == 0 ? "" : " " + res);
                num /= 1000;
                i++;
            }
            return string.IsNullOrEmpty(res) ? "Zero" : 
                    isNegative ? "Negative" + " " + res : res;
        }
        public String Convert(int num)
        {
            String res = "";
            String[] ten = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            String[] hundred = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            String[] twenty = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            if (num > 0)
            {
                int temp = num / 100;
                if (temp > 0)
                {
                    res += ten[temp] + " Hundred";
                }
                temp = num % 100;
                if (temp >= 10 && temp < 20)
                {
                    if (!string.IsNullOrEmpty(res)) res += " ";
                    res = res + twenty[temp % 10];
                    return res;
                }
                else if (temp >= 20)
                {
                    temp = temp / 10;
                    if (!string.IsNullOrEmpty(res)) res += " ";
                    res = res + hundred[temp - 1];
                }
                temp = num % 10;
                if (temp > 0)
                {
                    if (!string.IsNullOrEmpty(res)) res += " ";
                    res = res + ten[temp];
                }
            }
            return res;
        }


        static void Main(string[] args)
        {
        }
    }
}
