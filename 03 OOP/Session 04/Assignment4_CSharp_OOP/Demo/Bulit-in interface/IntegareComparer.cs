using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bulit_in_interface
{
    internal class IntegareComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            int? xValue = (int?)x;
            int? yValue = (int?)y;
            if (xValue is null && yValue is null)
                return 0;
            if (xValue is null)
                return -1;
            if (yValue is null)
                return 1;
            return - xValue.Value.CompareTo(yValue.Value);
        }
    }
}
