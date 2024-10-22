﻿namespace Common.L2.Application
{
	public static class NumberHelper
	{
		public static string TooMan(this int price)
		{
			return $"{price:#,0} تومان";
		}

        public static string TooMan(this int price, bool ifPriceIsZeroReturnFree = false)
        {
            if (ifPriceIsZeroReturnFree && price == 0)
                return "رایگان";
            return $"{price:#,0} تومان";
        }

        public static string TooMan(this int? price)
		{
			return $"{price:#,0} تومان";
		}
		public static string SplitNumber(this int price)
		{
			return $"{price:#,0}";
		}
		public static string SplitNumber(this int? price)
		{
			return $"{price:#,0}";
		}
	}
}