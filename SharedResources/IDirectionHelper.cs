using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public interface IDirectionHelper<U>
    {
        bool IsParallellTo(int axis);
        bool IsPerpendicularTo(int axis);
    }
}
