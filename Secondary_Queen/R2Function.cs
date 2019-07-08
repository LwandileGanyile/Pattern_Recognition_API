using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;

namespace Secondary_Queen
{
    public class R2Function : IRotate<R2Function>, IReflect<R2Function>, IReflectable<R2Function>, ITranslate<R2Function>
    {

        private float xValue;
        private float yValue;


        public R2Function()
        {

        }

        public R2Function(string equation)
        {

        }

        public R2Function ReflectAboutAxis(int axisIndex)
        {
            throw new NotImplementedException();
        }

        public R2Function ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public R2Function RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public R2Function Translate(int coordinateSystemDirection, float amaunt)
        {
            throw new NotImplementedException();
        }
    }
}
