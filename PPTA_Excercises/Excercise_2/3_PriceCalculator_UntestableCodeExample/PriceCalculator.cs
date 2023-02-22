using System;

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
