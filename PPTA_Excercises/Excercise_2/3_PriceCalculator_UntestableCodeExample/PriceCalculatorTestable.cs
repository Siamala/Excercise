
using System;

namespace PPTA_Excercises.Excercise_2.Untestable_code
{
    public interface IDateTimeProvider
    {
        DayOfWeek DayOfWeek();
    }

    public class PriceCalculatorTestable
    {
        public int GetDiscountedPrice(int price, IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider.DayOfWeek() == DayOfWeek.Tuesday)
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
