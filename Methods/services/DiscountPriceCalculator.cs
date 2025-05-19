using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 1.5
    public class DiscountPriceCalculator
    {
        public double CalculateDiscountPrice(double fullPrice, ref double discount)
        {
            discount = discount < 0 ? -discount : discount;
            discount = discount > 100 ? 100 : discount;
            fullPrice = fullPrice < 0 ? -fullPrice : fullPrice;
            return fullPrice - fullPrice * (discount / 100);
        }
    }
}