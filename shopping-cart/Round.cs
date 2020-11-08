using System;

namespace shopping_cart
{
    public static class Round
    {
        public static decimal RoundHalfUp(decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}