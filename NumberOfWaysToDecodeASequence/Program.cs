using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfWaysToDecodeASequence
{
    class Program
    {
        static int countDecoding(char[] digits, int n)
        {
            // base cases
            if (n == 0 || n == 1)
                return 1;

            // Initialize count
            int count = 0;

            // If the last digit is not 0, then 
            // last digit must add to
            // the number of words
            if (digits[n - 1] > '0')
                count = countDecoding(digits, n - 1);

            // If the last two digits form a number
            // smaller than or equal to 26, then 
            // consider last two digits and recur
            if (digits[n - 2] == '1' ||
                        (digits[n - 2] == '2' &&
                           digits[n - 1] < '7'))
                count += countDecoding(digits, n - 2);
            return count;
        }

        int countDecodingDP(string digits, int n)
        {
            int[] count = new int[n + 1]; // A table to store results of subproblems
            count[0] = 1;
            count[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                count[i] = 0;
                // If the last digit is not 0, then last digit must add to
                // the number of words
                if (digits[i - 1] > '0')
                    count[i] = count[i - 1];

                // If second last digit is smaller than 2 and last digit is
                // smaller than 7, then last two digits form a valid character
                if (digits[i - 2] == '1' || (digits[i - 2] == '2' && digits[i - 1] < '7'))
                    count[i] += count[i - 2];
            }
            return count[n];
        }

        // O(n) space
        public int NumOfDecodingWays(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var dp = new int[input.Length + 1];
            dp[0] = 1;
            dp[1] = input[0] == '0' ? 0 : 1;  

            for (int i = 2; i <= input.Length; i++)
            {
                // two possible decoding ways
                int first = Convert.ToInt32(input[i - 1]);
                int second = Convert.ToInt32(input.Substring(i - 2, 2));
                if (first > 0 && first < 10)
                {
                    // dp2 += dp1
                    dp[i] += dp[i - 1];
                }
                if (second >= 10 && second <= 26)
                {
                    // dp2 + = dp0;
                    dp[i] += dp[i - 2];
                }

                // update dp[i]
                /*
                 dp0 = dp1
                 dp1 = dp2
                */
            }

            // return dp2;
            return dp[input.Length];
        }

        // O(1) space
        public int NumOfDecodingWaysO1Space(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            int dp0 = input[0] == '0' ? 0 : 1;
            int dp1 = 1;
            var dp2 = dp0;

            for (int i = 1; i <= input.Length; i++)
            {
                dp2 = 0;

                // if this is smaller than 9
                if (input[i] != '0')
                {
                    dp2 += dp0;
                }

                // is between 10 and 26
                int num = Convert.ToInt32(input.Substring(i - 1, 2));
                if (num >= 10 && num <= 26)
                {
                    dp2 += dp1;
                }

                if (dp2 == 0)
                {
                    break;
                }

                // update 
                dp1 = dp0;
                dp0 = dp2;
            }

            return dp2;
        }


        // 102512 
        public static int NumOfDecodingWaysO1SpaceAlt(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !IsValid(input[0]))
            {
                return 0;
            }

            if (input.Length == 1)
            {
                return 1;
            }

            int m_curr = 1;
            int m_prev = 1; 

            for (int i = 1; i < input.Length; i++)
            {
                if (!IsValid(input[i]) && !IsValid(input[i - 1], input[i]))
                {
                    return 0;
                }

                int m = 0;

                // is between 1 and 9
                if (IsValid(input[i]))
                {
                    m = m_curr;
                }

                // if it is between 10 and 26
                if (IsValid(input[i - 1], input[i]))
                {
                    m = m_prev + m;
                }

                // save current state
                m_prev = m_curr;
                m_curr = m;
            }

            return m_curr;
        }

        private static bool IsValid(char c)
        {
            var num = Convert.ToInt32(c.ToString());
            return num > 0 && num <= 9;
        }

        private static bool IsValid(char c1, char c2)
        {
            if (Convert.ToInt32(c1.ToString()) == 0)
            {
                return false;
            }

            int num = Convert.ToInt32(c1.ToString() + c2.ToString());
            return num >= 10 && num <= 26;
        }

        static void Main(string[] args)
        {
            var test = NumOfDecodingWaysO1SpaceAlt("102512"); // => 2, 5, 12; 2 5 1 2; 25 12; 25 1 2;
            Console.Write(test);
        }
    }
}
