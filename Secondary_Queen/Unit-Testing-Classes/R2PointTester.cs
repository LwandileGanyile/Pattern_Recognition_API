using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen.Unit_Testing_Classes
{
    public class R2PointTester
    {
        protected internal List<R2Point> _points = new List<R2Point>();

        public R2PointTester()
        {
            _points.Add(new R2Point());
            _points.Add(new R2Point(10, 10));
            _points.Add(new R2Point(-10, -10));
            _points.Add(new R2Point(-10, 10));
            _points.Add(new R2Point(17, -10));
            _points.Add(new R2Point(60, 10));
            _points.Add(new R2Point(-10, -100));
            _points.Add(new R2Point(-10, 10));
            _points.Add(new R2Point(190, -10, true));

        }

        public void TestTranslate()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    _points[i].Display();
                    Console.Write(" --> ");


                    Console.Write("Translated in direction " + j + " 10 units.");
                    _points[i].Translate(j, 10).Display();
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                _points[i].Display();
                Console.Write(" --> ");
                _points[i].Translate(0, 2).Display();
                Console.WriteLine();
            }
        }

        public void ReflectAllAroundEqualAxis()
        {

            var directions = new int[8, 2];

            // Direction 1
            directions[0, 0] = -1;
            directions[0, 1] = 0;

            // Direction 2
            directions[1, 0] = 0;
            directions[1, 1] = 1;

            // Direction 3
            directions[2, 0] = 0;
            directions[2, 1] = -1;

            // Direction 4
            directions[3, 0] = -1;
            directions[3, 1] = 1;

            // Direction 5
            directions[4, 0] = 1;
            directions[4, 1] = -1;

            // Direction 6
            directions[5, 0] = 1;
            directions[5, 1] = 1;

            // Direction 7
            directions[6, 0] = -1;
            directions[6, 1] = -1;

            // Direction 8
            directions[7, 0] = 1;
            directions[7, 1] = 0;

            for (int i = 0; i < _points.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _points[i].Display();
                    Console.Write(" --> ");


                    Console.Write("Reflected about the line y = x. ");

                    _points[i].ReflectAboutEqualAxis(new List<int> { directions[j, 0], directions[j, 1], 1 }, 1).Display();
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
