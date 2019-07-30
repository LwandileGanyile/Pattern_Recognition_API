using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public interface ISharedDirection
    {
        float Divisor { get; set; }
        // Contains the axis components. E.g. x, y & z for an R3 direction/vector.
        List<float> Length { get; set; }

        float GetDirectionLength();
        int GetNumberOfElements();
        float GetDirectionLengthComponent(int componentIndex);
    }
}
