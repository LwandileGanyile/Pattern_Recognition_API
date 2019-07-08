using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;
using Interaction;
using ShootingStrategy;

namespace Secondary_Queen
{
    public class Intelligence : StrategyIntelligence
    {
        private Dictionary<VectorShootingStrategy, float> intelligence = new Dictionary<VectorShootingStrategy, float>();


        public Intelligence()
        {

        }

        public Intelligence(List<float> multiples)
        {

        }

        public Intelligence(List<ISecondaryMovingStrategy> movingStrategys)
        {

        }

        public Intelligence(List<Rhythm> rhythms)
        {

        }

        public Intelligence(List<Music> musicList)
        {

        }

        public Intelligence(List<Rhythm> rhythms, List<Music> musicList)
        {

        }

        public Intelligence(List<ISecondaryMovingStrategy> movingStrategys, List<Music> musicList)
        {

        }

        public Intelligence(List<ISecondaryMovingStrategy> movingStrategys, List<Rhythm> rhythms)
        {

        }

        public Intelligence(List<float> multiples, List<Music> musicList)
        {

        }

        public Intelligence(List<float> multiples, List<Rhythm> rhythms)
        {

        }

        public Intelligence(List<float> multiples, List<ISecondaryMovingStrategy> movingStrategys)
        {

        }



        public Intelligence(List<float> multiples, List<ISecondaryMovingStrategy> movingStrategys,
                                                 List<Music> musicList)
        {

        }

        public Intelligence(List<float> multiples, List<ISecondaryMovingStrategy> movingStrategys, List<Rhythm> rhythms)
        {

        }



        public Intelligence(List<ISecondaryMovingStrategy> movingStrategys, List<Rhythm> rhythms,
                                                 List<Music> musicList)
        {

        }

        public Intelligence(List<float> multiples, List<Rhythm> rhythms,
                                                 List<Music> musicList)
        {

        }



        public Intelligence(List<float> multiples, List<ISecondaryMovingStrategy> movingStrategys, List<Rhythm> rhythms,
                                                 List<Music> musicList)
        {

        }



        public Intelligence(List<float> multiples, List<byte> permutationLengths,
                                                 List<ISecondaryMovingStrategy> movingStrategys, List<Rhythm> rhythms,
                                                 List<Music> musicList)
        {

        }


        public void IncreaseIntelligence(byte movingStrategyLengthKey, float amount)
        {

        }



        public void DecreaseIntelligence(byte movingStrategyLengthKey, float amount)
        {

        }

        public bool IsPartialSmart(float multiple, Intelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(Music music, Intelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(Rhythm rhythm, Intelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(ISecondaryMovingStrategy movingStrategy, Intelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(VectorShootType vectorShootType)
        {
            return true;
        }

        public Dictionary<int, float> GetPartialIntelligence(VectorShootType vectorShootType)
        {
            return null;
        }
    }
}
