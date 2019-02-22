using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.Tools
{
    public interface IRandomizer
    {
        int GetChanceRatio(int min = 1, int max = 100);
    }
}
