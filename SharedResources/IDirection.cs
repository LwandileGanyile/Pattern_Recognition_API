using Game_Defination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public interface IDirection<T> : IRotate<T>, IRotateable<T>, IReflect<T>, IReflectable<T>,
    ITranslate<T>, IDisplay, ICompare<T>
    {

        bool IsDirectionValid(int direction);


    }
}
