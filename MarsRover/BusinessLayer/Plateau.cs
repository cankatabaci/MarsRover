using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer
{
    public class Plateau
    {
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public static int MinWidth { get; set; } = 0;
        public static int MinHeight { get; set; } = 0;

        public Plateau(List<int> maxRange)
        {
            MaxWidth = maxRange[0];
            MaxHeight = maxRange[1];
        }
    }
}
