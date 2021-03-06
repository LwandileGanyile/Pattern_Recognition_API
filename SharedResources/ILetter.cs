﻿using Game_Defination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public interface ILetter<T> : IRotate<T>, IRotateable<T>, IReflect<T>, IReflectable<T>,
    ITranslate<T>, IDisplay, ICompare<T>
    {
        void DisplayLetterInfo();

        bool IsC(List<int> directions, List<ISharedDirection> lengths);
        bool IsI(List<int> directions, List<ISharedDirection> lengths);
        bool IsL(List<int> directions, List<ISharedDirection> lengths);
        bool IsM(List<int> directions, List<ISharedDirection> lengths);
        bool IsN(List<int> directions, List<ISharedDirection> lengths);
        bool IsO(List<int> directions, List<ISharedDirection> lengths);
        bool IsR(List<int> directions, List<ISharedDirection> lengths);
        bool IsS(List<int> directions, List<ISharedDirection> lengths);
        bool IsW(List<int> directions, List<ISharedDirection> lengths);
        bool IsLetter(List<int> directions, List<ISharedDirection> lengths);

    }
}
