using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic.Helpers
{
    public class ColorHelper
    {
        public static string GetRandomColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
    }
}
