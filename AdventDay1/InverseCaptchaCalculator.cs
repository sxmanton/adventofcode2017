using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay1
{
    public static class InverseCaptchaCalculator
    {
        public static int SumRepeatedDigits(string captcha)
        {
            var sum = 0;
            for (int i = 0; i < captcha.Length; i++)
            {
                if (captcha[i] == captcha[(i + 1) % captcha.Length])
                {
                    sum += int.Parse(captcha[i].ToString());
                }
            }

            return sum;
        }

        public static int SumSameHalfwayAroundDigits(string captcha)
        {
            var sum = 0;
            int halfway = captcha.Length / 2;
            for (int i = 0; i < captcha.Length; i++)
            {
                if (captcha[i] == captcha[(i + halfway) % captcha.Length])
                {
                    sum += int.Parse(captcha[i].ToString());
                }
            }

            return sum;
        }
    }
}
