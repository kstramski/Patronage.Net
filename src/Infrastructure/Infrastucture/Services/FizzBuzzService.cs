using System;
using System.Net;
using Application.Exceptions;
using Application.Interfaces;

namespace Infrastructure.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public string FizzBuzz(int number)
        {
            var result = String.Empty;

            if (number > 1000 || number < 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Invalid input value. Value should be between 0 and 1000");
            }

            if (NumberMod(number, 2) && NumberMod(number, 3))
            {
                result = "FizzBuzz";
            }
            else if (NumberMod(number, 2))
            {
                result = "Fizz";
            }
            else if (NumberMod(number, 3))
            {
                result = "Buzz";
            }

            return result;
        }

        private static bool NumberMod(int number, int mod)
        {
            return (number % mod == 0) ? true : false;
        }
    }
}
