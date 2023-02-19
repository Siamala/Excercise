using System;

// Example taken from: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
namespace PPTA_Excercises.Excercise_2.Untestable_code
{
    public class PriceCalculator
    {
        public int GetDiscountedPrice(int price)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                return price / 2;
            }
            else
            {
                return price;
            }
        }
    }
}
