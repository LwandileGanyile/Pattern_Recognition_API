using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;
using MovingStrategy;

namespace Interaction
{
    public abstract class StrategyIntelligence
    {
        protected Dictionary<float, float> multiplesIntelligence = new Dictionary<float, float>();
        protected Dictionary<IMovingStrategy, float> movingStrategyIntelligence = new Dictionary<IMovingStrategy, float>();
        protected Dictionary<Rhythm, float> rhythmIntelligence = new Dictionary<Rhythm, float>();
        protected Dictionary<Music, float> musicIntelligence = new Dictionary<Music, float>();
        protected Dictionary<KingStep, float> kingStepsIntelligence = new Dictionary<KingStep, float>();



        protected StrategyIntelligence()
        {

        }



        protected StrategyIntelligence(List<float> multiples)
        {

        }

        protected StrategyIntelligence(List<byte> permutationLengths)
        {

        }



        protected StrategyIntelligence(List<float> multiples, List<byte> permutationLengths)
        {

        }


        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(Dictionary<KingStep, float> kingStepsIntelligence)
        {

        }

        protected StrategyIntelligence(Dictionary<KingStep, float> kingStepsIntelligence, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(Dictionary<KingStep, float> kingStepsIntelligence, List<float> multiples)
        {

        }

        protected StrategyIntelligence(Dictionary<KingStep, float> kingStepsIntelligence, List<Rhythm> rhythms)
        {

        }

        protected StrategyIntelligence(List<Rhythm> rhythms)
        {

        }

        protected StrategyIntelligence(List<Rhythm> rhythms, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<Music> musicList, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<Rhythm> rhythms, List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<Rhythm> rhythms, List<Music> musicList
        , List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<Music> musicList
        , List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms
        , List<byte> permutationLengths)
        {

        }



        protected StrategyIntelligence(List<float> multiples,
        List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<float> multiples,
        List<Music> musicList, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<Rhythm> rhythms)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<Rhythm> rhythms
        , List<byte> permutationLengths)
        {

        }

        public StrategyIntelligence(List<float> multiples,
        List<IMovingStrategy> movingStrategys)
        {

        }

        public StrategyIntelligence(List<float> multiples,
        List<IMovingStrategy> movingStrategys, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<IMovingStrategy> movingStrategys,
        List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<IMovingStrategy> movingStrategys,
        List<Music> musicList, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms
        , List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms,
         List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms,
        List<Music> musicList, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<Rhythm> rhythms,
                                                 List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<Rhythm> rhythms,
        List<Music> musicList, List<byte> permutationLengths)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms,
                                                 List<Music> musicList)
        {

        }

        protected StrategyIntelligence(List<float> multiples, List<IMovingStrategy> movingStrategys, List<Rhythm> rhythms,
                                                 List<Music> musicList, List<byte> permutationLengths)
        {

        }



        // Multiple Intelligence
        public float this[float multiple]
        {
            get
            { return multiplesIntelligence[multiple]; }

            set
            {
                multiplesIntelligence[multiple] = value;
            }
        }

        // Moving strategy length Intelligence
        /*public float this[byte movingStrategyLength]
        {
            get
            { return numberOfLettersIntelligence[movingStrategyLength]; }

            set
            {
                numberOfLettersIntelligence[movingStrategyLength] = value;
            }
        }*/



        // Moving strategy Intelligence
        public float this[IMovingStrategy movingStrategy]
        {
            get
            { return movingStrategyIntelligence[movingStrategy]; }

            set
            {
                movingStrategyIntelligence[movingStrategy] = value;
            }
        }

        // Rhythm Intelligence
        public float this[Rhythm rhythm]
        {
            get
            { return rhythmIntelligence[rhythm]; }

            set
            {
                rhythmIntelligence[rhythm] = value;
            }
        }

        // Music Intelligence
        public float this[Music music]
        {
            get
            { return musicIntelligence[music]; }

            set
            {
                musicIntelligence[music] = value;
            }
        }


        public void IncreaseIntelligence(Music musicKey, float amount)
        {

        }

        public void IncreaseIntelligence(Rhythm rhythmKey, float amount)
        {

        }

        public void IncreaseIntelligence(IMovingStrategy movingStrategyKey, float amount)
        {

        }

        public void IncreaseIntelligence(byte movingStrategyLengthKey, float amount)
        {

        }

        public void IncreaseIntelligence(float multipleKey, float amount)
        {

        }



        public void DecreaseIntelligence(Music musicKey, float amount)
        {

        }

        public void DecreaseIntelligence(Rhythm rhythmKey, float amount)
        {

        }

        public void DecreaseIntelligence(IMovingStrategy movingStrategyKey, float amount)
        {

        }

        public void DecreaseIntelligence(byte movingStrategyLength, float amount)
        {

        }

        public void DecreaseIntelligence(float multipleKey, float amount)
        {

        }



        public bool IsPartialSmart(float multiple, StrategyIntelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(byte moveLength, StrategyIntelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(Music music, StrategyIntelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(Rhythm rhythm, StrategyIntelligence intelligence)
        {
            return true;
        }

        public bool IsPartialSmart(IMovingStrategy movingStrategy, StrategyIntelligence intelligence)
        {
            return true;
        }


        public Dictionary<float, float> GetPartialIntelligence(float multiple)
        {
            return new Dictionary<float, float>();
        }

        public Dictionary<IMovingStrategy, float> GetPartialIntelligence(IMovingStrategy movingStrategy)
        {
            return new Dictionary<IMovingStrategy, float>();
        }

        public Dictionary<Rhythm, float> GetPartialIntelligence(Rhythm rhythm)
        {
            return new Dictionary<Rhythm, float>();
        }

        public Dictionary<byte, float> GetPartialIntelligence(byte moveLength)
        {
            return new Dictionary<byte, float>();
        }

        public Dictionary<Music, float> GetPartialIntelligence(Music music)
        {
            return new Dictionary<Music, float>();
        }


    }
}
