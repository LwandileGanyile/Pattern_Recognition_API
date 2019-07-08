using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;
using Recognition;
using MovingStrategy;
using ShootingStrategy;
using Secondary_Queen;

namespace Secondary_Queen.Unit_Testing_Classes
{
    public class RhythmPatternTester
    {

        private RhythmPattern rhythmPattern21;
        private RhythmPattern rhythmPattern22;
        private RhythmPattern rhythmPattern23;

        private List<Rhythm> rhythmsForSecondaryMovingStrategy = new List<Rhythm>();

        private List<IMovingStrategy> secondaryCircularShapeMovingStrategies = new List<IMovingStrategy>();
        private List<IMovingStrategy> secondaryNonCircularShapeMovingStrategies = new List<IMovingStrategy>();
        private List<IMovingStrategy> secondaryCircularLetterMovingStrategies = new List<IMovingStrategy>();
        private List<IMovingStrategy> secondaryNonCircularLetterMovingStrategies = new List<IMovingStrategy>();

        private List<IShootingStrategy> secondaryCircularShootingStrategies = new List<IShootingStrategy>();
        private List<IShootingStrategy> secondaryNonCircularShootingStrategies = new List<IShootingStrategy>();

        private List<float> multiples;
        private List<StageChange> stageChanges;
        private List<Rhythm> rhythms;

        public RhythmPatternTester()
        {
            /*FillRhythms();
            FillMultiples();
            FillStageChanges();
            FillCircularMovingStrategy();
            FillNonCircularMovingStrategy();
            */


            rhythmPattern21 = new RhythmPattern(rhythms, secondaryCircularShapeMovingStrategies,
            multiples, stageChanges, true);

            rhythmPattern22 = new RhythmPattern(rhythms, secondaryNonCircularShapeMovingStrategies,
            multiples, stageChanges, true);
        }

        private void FillMultiples()
        {
            multiples = new List<float>();
            for (float i = 0; i < 12; i++)
                multiples.Add(i + 1);
        }


        private void FillStageChanges()
        {
            stageChanges = new List<StageChange>();

            stageChanges.Add(StageChange.CHANGE_ROTATION_OR_REPEATATION);
            stageChanges.Add(StageChange.CHANGE_SHOOTING_STRATEGY);
            stageChanges.Add(StageChange.CHANGE_MULTIPLE);
            stageChanges.Add(StageChange.CHANGE_MOVING_STRATEGY);
            stageChanges.Add(StageChange.CHANGE_MUSIC);
            stageChanges.Add(StageChange.CHANGE_RHYTHM);

        }

        private void FillCircularMovingStrategy()
        {
            /*secondaryCircularShapeMovingStrategies = new List<IMovingStrategy>();
            secondaryCircularLetterMovingStrategies = new List<IMovingStrategy>();

            List<R2CDirection> movingStrategy = new List<R2CDirection>();
            FillCircular(movingStrategy);

            R2CMovingStrategy movingStrategy11 = new R2CMovingStrategy();
            primaryCircularMovingStrategies.Add(movingStrategy11);


            R2CMovingStrategy movingStrategy21 = new R2CMovingStrategy(movingStrategy, ShapeTraceType.Point_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy21);
            R2CMovingStrategy movingStrategy22 = new R2CMovingStrategy(movingStrategy, ShapeTraceType.Direction_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy22);

            R2CMovingStrategy movingStrategy31 = new R2CMovingStrategy(new R1Point(), 1, ShapeTraceType.Point_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy31);
            R2CMovingStrategy movingStrategy32 = new R2CMovingStrategy(new R1Point(), 2, ShapeTraceType.Direction_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy32);
            R2CMovingStrategy movingStrategy33 = new R2CMovingStrategy(new R1Point(), 3, ShapeTraceType.Point_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy33);
            R2CMovingStrategy movingStrategy34 = new R2CMovingStrategy(new R1Point(), 4, ShapeTraceType.Direction_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy34);
            R2CMovingStrategy movingStrategy35 = new R2CMovingStrategy(new R1Point(), 5, ShapeTraceType.Point_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy35);
            R2CMovingStrategy movingStrategy36 = new R2CMovingStrategy(new R1Point(), 6, ShapeTraceType.Direction_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy36);
            R2CMovingStrategy movingStrategy37 = new R2CMovingStrategy(new R1Point(), 7, ShapeTraceType.Point_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy37);
            R2CMovingStrategy movingStrategy38 = new R2CMovingStrategy(new R1Point(), 8, ShapeTraceType.Direction_Trace);
            primaryCircularMovingStrategies.Add(movingStrategy38);*/
        }

        private void FillCircular(List<R2CDirection> movingStrategy)
        {
            Dictionary<int, int> duration = new Dictionary<int, int>();

            for (int i = 1; i <= 5; i++)
                duration.Add(i, 200);

            R2CDirection firstDirection = new R2CDirection(new R2Point(), 1, 10, 2, duration);
            R2CDirection secondDirection = new R2CDirection(firstDirection.GetLast(), 2, 10, 2, duration);
            R2CDirection thirdDirection = new R2CDirection(secondDirection.GetLast(), 3, 10, 2, duration);
            R2CDirection forthDirection = new R2CDirection(thirdDirection.GetLast(), 4, 10, 2, duration);
            R2CDirection fifthDirection = new R2CDirection(thirdDirection.GetLast(), 5, 10, 2, duration);
            R2CDirection sixthDirection = new R2CDirection(thirdDirection.GetLast(), 6, 10, 2, duration);
            R2CDirection seventhDirection = new R2CDirection(thirdDirection.GetLast(), 7, 10, 2, duration);
            R2CDirection eighteethDirection = new R2CDirection(thirdDirection.GetLast(), 8, 10, 2, duration);



            movingStrategy.Add(firstDirection);
            movingStrategy.Add(secondDirection);
            movingStrategy.Add(thirdDirection);
            movingStrategy.Add(forthDirection);
            movingStrategy.Add(fifthDirection);
            movingStrategy.Add(sixthDirection);
            movingStrategy.Add(seventhDirection);
            movingStrategy.Add(eighteethDirection);
        }
    }
}
