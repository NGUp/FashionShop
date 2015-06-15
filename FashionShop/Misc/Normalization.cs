using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Misc
{
    public class Normalization
    {
        public static string standardizePrice(int price)
        {
            string tmp = price.ToString();
            int step = 0, index;

            for (index = tmp.Length - 1; index > 0; index--)
            {
                if (step == 2)
                {
                    tmp = tmp.Insert(index, ".");
                    index--;
                    step = 0;
                }

                step++;
            }

            return tmp;
        }
    }
}