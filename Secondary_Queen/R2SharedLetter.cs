using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen
{
    public class R2SharedLetter<T, U> : SharedLetter<T, U>
    {
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override int CompareTo(Helper<T, U> other)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Fill()
        {
            throw new NotImplementedException();
        }

        public override Helper<T, U> GetOppositeDirection()
        {
            throw new NotImplementedException();
        }

        public override T ReflectAboutAxis(int axisIndex)
        {
            throw new NotImplementedException();
        }

        public override Helper<T, U> ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override T Translate(int coordinateSystemDirection, float amaunt)
        {
            throw new NotImplementedException();
        }

        protected override void InstantiateDirection(U[] points)
        {
            throw new NotImplementedException();
        }
    }
}
