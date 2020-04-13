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
            return $"#{random.Next(0x1000000):X6}";
        }
    }
}
