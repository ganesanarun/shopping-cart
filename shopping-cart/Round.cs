using System;

namespace shopping_cart
{
    public class Round
    {
        public static decimal RoundHalfUp(decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}