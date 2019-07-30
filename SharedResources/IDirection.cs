﻿using Game_Defination;
using Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public interface IDirection<T> : IRotate<T>, IRotateable<T>, IReflect<T>, IReflectable<T>,
    ITranslate<T>, IDisplay, IComparable<T>
    {
        bool IsDirectionValid(int direction);

        /*new int CompareTo(T other);
        new void Display();
        new T ReflectAboutAxis(int axisIndex);
        new T ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes);
        new T RotateAroundAxis(int indexOfAxis, int numberOfTimes);
        new T RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes);
        new T Translate(int coordinateSystemDirection, float amaunt);*/
    }
}
