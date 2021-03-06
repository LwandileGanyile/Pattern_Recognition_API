﻿using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen
{
    public class SharedDirection : ISharedDirection
    {
        private SharedResources.SharedDirection sharedDirection;

        public float Divisor
        {
            get
            {
                return sharedDirection.Divisor;
            }

            set
            {
                if (value > 0 && value % sharedDirection.Divisor == 0)
                    sharedDirection.Divisor = value;
            }
        }

        public List<float> Length
        {
            get { return sharedDirection.Length; }
            set { sharedDirection.Length = value; }
        }

        public float XLength
        {
            get
            {
                return sharedDirection.Length[0];
            }

            set
            {

                if (value > 0 && value % sharedDirection.Divisor == 0)
                    sharedDirection.Length[0] = value;

            }
        }

        public float YLength
        {
            get
            {
                return sharedDirection.Length[1];
            }

            set
            {

                if (value > 0 && value % sharedDirection.Divisor == 0)
                    sharedDirection.Length[1] = value;

            }
        }

        public SharedDirection()
        : this(2)
        {

        }

        public SharedDirection(float _divisor)
        : this(12, 12,_divisor)
        {

        }

        public SharedDirection(float _xLength, float _yLength, float _divisor)
        {
            if (!(_xLength % _divisor == 0 && _yLength % _divisor == 0))
                throw new Exception("Make sure the components of a direction length are a number divisible by the divisor.");

            sharedDirection = new SharedResources.SharedDirection(new List<float>() { _xLength, _yLength }, _divisor);
        }

        public float GetDirectionLength()
        {
            return sharedDirection.GetDirectionLength();
           
        }

        public override string ToString()
        {
            return sharedDirection.ToString();
        }

        public float GetDirectionLengthComponent(int componentIndex)
        {
            return sharedDirection.GetDirectionLengthComponent(componentIndex);
        }

        public int GetNumberOfElements()
        {
            return ((ISharedDirection)sharedDirection).GetNumberOfElements();
        }
    }
}
