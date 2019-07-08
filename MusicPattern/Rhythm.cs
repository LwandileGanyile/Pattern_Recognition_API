using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPattern
{
    public class Rhythm
    {
        private Dictionary<int, int> _rhythmStructure;
        private List<bool> _ignoreClaps;
        private bool _isComputerGenerated;
        private RhythmType _rhythmType;
        private RhythmClass _rhythmClass;

        public Rhythm()
        {
            _ignoreClaps = new List<bool>();
            _rhythmStructure = new Dictionary<int, int>();
            _isComputerGenerated = false;
            _rhythmType = RhythmType.SIMILAR_CLAPS;
            _rhythmClass = RhythmClass.RHYTHM_ONE;

            for (int index = 1; index <= 300; index++)
            {
                _ignoreClaps.Add(false);
                _rhythmStructure.Add(index * 1000, 1);
            }
        }

        public Rhythm(RhythmClass rhythmClass, int numberOfSeconds)
        {
            _ignoreClaps = new List<bool>();
            _rhythmStructure = new Dictionary<int, int>();
            _isComputerGenerated = false;
            _rhythmClass = rhythmClass;

            FillRhythmStructure(rhythmClass, numberOfSeconds);
            FillIgnoreClaps(numberOfSeconds);

            DetermineRhythmType();

        }


        public Rhythm(RhythmClass rhythmClass, int numberOfSeconds, List<bool> _ignoreClaps)
        {
            _rhythmClass = rhythmClass;
            _rhythmStructure = new Dictionary<int, int>();
            _isComputerGenerated = false;
            FillRhythmStructure(rhythmClass, numberOfSeconds);

            if (_rhythmStructure.Count == _ignoreClaps.Count)
                this._ignoreClaps = _ignoreClaps;
            else
                FillIgnoreClaps(numberOfSeconds);

            DetermineRhythmType();
        }

        public Rhythm(RhythmClass rhythmClass, Dictionary<int, int> _rhythmStructure, List<bool> _ignoreClaps, bool _isComputerGenerated)
        {
            this._rhythmStructure = _rhythmStructure;
            this._ignoreClaps = _ignoreClaps;
            this._isComputerGenerated = _isComputerGenerated;

            _rhythmClass = rhythmClass;
            DetermineRhythmType();

        }

        // Used to create rhythms using AI algorithms.
        public Rhythm(Dictionary<int, int> _rhythmStructure, List<bool> _ignoreClaps)
        {
            this._rhythmStructure = _rhythmStructure;
            this._ignoreClaps = _ignoreClaps;
            _isComputerGenerated = true;
            _rhythmClass = RhythmClass.GENERAL_RHYTHM;
            _rhythmType = RhythmType.GENERAL_CLAPS;

        }

        public Dictionary<int, int> RhythmStructure { get; }

        public List<bool> IgnoreClaps { get; }

        public RhythmType RhythmType { get; }
        public RhythmClass RhythmClass { get; }

        public bool IsComputerGenerated { get; }

        // Categorize a rhythm class into different rhythm types.
        public RhythmType DetermineRhythmType()
        {
            if (_rhythmClass == RhythmClass.RHYTHM_ONE || _rhythmClass == RhythmClass.RHYTHM_TWO ||
                _rhythmClass == RhythmClass.RHYTHM_THREE)
                _rhythmType = RhythmType.SIMILAR_CLAPS;
            else if (_rhythmClass == RhythmClass.RHYTHM_FOUR || _rhythmClass == RhythmClass.RHYTHM_FIVE ||
                _rhythmClass == RhythmClass.RHYTHM_SIX)
                _rhythmType = RhythmType.TWO_ALTERNATING_DISTINCT_CLAPS;
            else if (_rhythmClass == RhythmClass.RHYTHM_SEVEN || _rhythmClass == RhythmClass.RHYTHM_EIGHT ||
                 _rhythmClass == RhythmClass.RHYTHM_NINE || _rhythmClass == RhythmClass.RHYTHM_TEN ||
                 _rhythmClass == RhythmClass.RHYTHM_ELEVEN || _rhythmClass == RhythmClass.RHYTHM_TWELVE)
                _rhythmType = RhythmType.THREE_ALTERNATING_DISTINCT_CLAPS;
            else
                _rhythmType = RhythmType.GENERAL_CLAPS;
            return _rhythmType;
        }

        // Non of the rhythm claps is ignored.
        public void FillIgnoreClaps(int numberOfSeconds)
        {
            for (int index = 1; index <= numberOfSeconds; index++)
            {
                _ignoreClaps.Add(false);
            }
        }

        // Create any one of the twelve rhythms strucures.
        // This method only works with predefined rhythm classes.
        // Meaning a general rhythm structure isn't applicable of this method.
        public void FillRhythmStructure(RhythmClass rhythmClass, int numberOfSeconds)
        {
            switch (rhythmClass)
            {
                case RhythmClass.RHYTHM_ONE:// 1 1 1 1 1...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        _rhythmStructure.Add(index * 1000, 1);
                    }
                    break;
                case RhythmClass.RHYTHM_TWO:// 2 2 2 2 2...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        _rhythmStructure.Add(index * 1000, 2);
                    }
                    break;
                case RhythmClass.RHYTHM_THREE:// 3 3 3 3 3 3...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        _rhythmStructure.Add(index * 1000, 3);
                    }
                    break;
                case RhythmClass.RHYTHM_FOUR:// 2 1 2 1 2 1...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 2 == 0)
                            _rhythmStructure.Add(index * 1000, 1);
                        else
                            _rhythmStructure.Add(index * 1000, 2);
                    }
                    break;
                case RhythmClass.RHYTHM_FIVE:// 3 1 3 1 3 1...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 2 == 0)
                            _rhythmStructure.Add(index * 1000, 1);
                        else
                            _rhythmStructure.Add(index * 1000, 3);
                    }
                    break;
                case RhythmClass.RHYTHM_SIX:// 3 2 3 2 3 2...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 2 == 0)
                            _rhythmStructure.Add(index * 1000, 2);
                        else
                            _rhythmStructure.Add(index * 1000, 3);
                    }
                    break;
                case RhythmClass.RHYTHM_SEVEN:// 2 3 1 2 3 1...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 3 == 0)
                            _rhythmStructure.Add(index * 1000, 1);
                        else if (index % 3 == 1)
                            _rhythmStructure.Add(index * 1000, 2);
                        else
                            _rhythmStructure.Add(index * 1000, 3);
                    }
                    break;
                case RhythmClass.RHYTHM_EIGHT:// 2 1 3 2 1 3 2 1 3...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 3 == 0)
                            _rhythmStructure.Add(index * 1000, 3);
                        else if (index % 3 == 1)
                            _rhythmStructure.Add(index * 1000, 2);
                        else
                            _rhythmStructure.Add(index * 1000, 1);
                    }
                    break;
                case RhythmClass.RHYTHM_NINE:// 3 2 1 3 2 1 3 2 1...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 3 == 0)
                            _rhythmStructure.Add(index * 1000, 1);
                        else if (index % 3 == 1)
                            _rhythmStructure.Add(index * 1000, 3);
                        else
                            _rhythmStructure.Add(index * 1000, 2);
                    }
                    break;
                case RhythmClass.RHYTHM_TEN:// 1 2 3 1 2 3...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 3 == 0)
                            _rhythmStructure.Add(index * 1000, 3);
                        else if (index % 3 == 1)
                            _rhythmStructure.Add(index * 1000, 1);
                        else
                            _rhythmStructure.Add(index * 1000, 2);
                    }
                    break;
                case RhythmClass.RHYTHM_ELEVEN: // 1 3 2 1 3 2...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 3 == 0)
                            _rhythmStructure.Add(index * 1000, 2);
                        else if (index % 3 == 1)
                            _rhythmStructure.Add(index * 1000, 1);
                        else
                            _rhythmStructure.Add(index * 1000, 3);
                    }
                    break;
                default: // 3 1 2 3 1 2...
                    for (int index = 1; index <= numberOfSeconds; index++)
                    {
                        if (index % 3 == 0)
                            _rhythmStructure.Add(index * 1000, 2);
                        else if (index % 3 == 1)
                            _rhythmStructure.Add(index * 1000, 3);
                        else
                            _rhythmStructure.Add(index * 1000, 1);
                    }
                    break;
            }
        }

        // Change the number of claps at a specific time/key.
        public void SetClapsAt(int atTime, int numberOfClaps)
        {
            if (numberOfClaps > 0 && _rhythmStructure.ContainsKey(atTime) &&
                numberOfClaps > 0 && numberOfClaps < 4)
                _rhythmStructure[atTime] = numberOfClaps;
        }

        // Add a certain number of claps at a specific time/key.
        public void AddClapsAt(int atTime, int numberOfClaps)
        {
            if (numberOfClaps > 0 && _rhythmStructure.ContainsKey(atTime))
            {
                if (_rhythmStructure[atTime] + numberOfClaps <= 3)
                    _rhythmStructure[atTime] += numberOfClaps;
                else
                    _rhythmStructure[atTime] = 3;
            }

        }

        // Remove a certain number of claps at a specific time/key.
        public void RemoveClapsAt(int atTime, int numberOfClaps)
        {
            if (numberOfClaps > 0 && _rhythmStructure.ContainsKey(atTime))
            {
                if (_rhythmStructure[atTime] - numberOfClaps >= 1)
                    _rhythmStructure[atTime] -= numberOfClaps;
                else
                    _rhythmStructure[atTime] = 1;
            }

        }

        // Remove claps at a specific index.
        public bool RemoveClapsAt(int atTime)
        {
            bool removed = false;

            if (_rhythmStructure.ContainsKey(atTime))
            {
                _rhythmStructure.Remove(atTime);
                removed = true;
            }


            return removed;
        }

        // Shift the entire rhythm left.
        public bool ShiftRhythmLeft(int timeInMilliSeconds)
        {
            bool shifted = false;

            if (_rhythmStructure.First().Key - timeInMilliSeconds >= 0)
            {
                ICollection<int> keys = _rhythmStructure.Keys;
                ICollection<int> values = _rhythmStructure.Values;

                _rhythmStructure = new Dictionary<int, int>();



                for (int i = 0; i < keys.Count; i++)
                    _rhythmStructure.Add(keys.ElementAt(i) - timeInMilliSeconds, values.ElementAt(i));

                shifted = true;
            }

            return shifted;
        }

        // Shift the entire rhythm right.
        public bool ShiftRhythmRight(int timeInMilliSeconds)
        {
            bool shifted = false;

            if (_rhythmStructure.First().Key + timeInMilliSeconds <= _rhythmStructure.Last().Key)
            {
                ICollection<int> keys = _rhythmStructure.Keys;
                ICollection<int> values = _rhythmStructure.Values;

                _rhythmStructure = new Dictionary<int, int>();



                for (int i = 0; i < keys.Count; i++)
                    _rhythmStructure.Add(keys.ElementAt(i) + timeInMilliSeconds, values.ElementAt(i));

                shifted = true;
            }

            return shifted;
        }

        // Shift the claps right.
        public bool ShiftClapsRight(int atTime, int timeInMilliSeconds)
        {
            bool shifted = false;
            Dictionary<int, int> structure = new Dictionary<int, int>();

            if (_rhythmStructure.ContainsKey(atTime))
            {

                ICollection<int> keys = _rhythmStructure.Keys;
                ICollection<int> values = _rhythmStructure.Values;

                int indexOfKey = -1;
                int currentIndex = -1;

                while (indexOfKey == -1)
                {
                    currentIndex++;
                    if (keys.ElementAt(currentIndex) == atTime)

                        indexOfKey = currentIndex;

                }

                if (indexOfKey < keys.Count - 1)
                {
                    for (int i = 0; i < keys.Count; i++)
                    {
                        if (i == indexOfKey)
                        {
                            if (keys.ElementAt(indexOfKey) + timeInMilliSeconds < keys.ElementAt(indexOfKey + 1))
                            {
                                structure.Add(keys.ElementAt(indexOfKey) + timeInMilliSeconds, values.ElementAt(indexOfKey));
                                shifted = true;
                            }
                            else
                                structure.Add(keys.ElementAt(i), values.ElementAt(i));
                        }
                        else

                            structure.Add(keys.ElementAt(i), values.ElementAt(i));


                        _rhythmStructure = structure;

                    }
                }

                else
                {
                    for (int i = 0; i < keys.Count; i++)
                    {
                        structure.Add(keys.ElementAt(i), values.ElementAt(i));
                    }

                    structure.Add(keys.ElementAt(keys.Count - 1) + timeInMilliSeconds, values.ElementAt(keys.Count - 1));
                }
            }

            return shifted;
        }

        // Shift the claps left.
        public bool ShiftClapsLeft(int atTime, int timeInMilliSeconds)
        {
            bool shifted = false;

            Dictionary<int, int> structure = new Dictionary<int, int>();


            if (_rhythmStructure.ContainsKey(atTime))
            {

                ICollection<int> keys = _rhythmStructure.Keys;
                ICollection<int> values = _rhythmStructure.Values;

                int indexOfKey = -1;
                int currentIndex = -1;

                while (indexOfKey == -1)
                {
                    currentIndex++;
                    if (keys.ElementAt(currentIndex) == atTime)

                        indexOfKey = currentIndex;

                }

                if (indexOfKey == 0)
                {
                    if (((keys.ElementAt(indexOfKey) - Math.Abs(timeInMilliSeconds)) > 0))
                    {
                        structure.Add(keys.ElementAt(indexOfKey) - Math.Abs(timeInMilliSeconds), values.ElementAt(0));

                        for (int i = 1; i < keys.Count; i++)
                            structure.Add(keys.ElementAt(i), values.ElementAt(i));

                        shifted = true;
                        _rhythmStructure = structure;
                    }
                }

                else
                {
                    if (((keys.ElementAt(indexOfKey) - Math.Abs(timeInMilliSeconds)) > keys.ElementAt(indexOfKey - 1)))
                    {
                        for (int i = 0; i < keys.Count; i++)
                            if (i == indexOfKey)
                                structure.Add(keys.ElementAt(indexOfKey) - Math.Abs(timeInMilliSeconds), values.ElementAt(indexOfKey));
                            else
                                structure.Add(keys.ElementAt(i), values.ElementAt(i));



                        shifted = true;

                        _rhythmStructure = structure;
                    }
                }


            }


            return shifted;
        }

        // Change the ignore property of claps/clap.
        public void SetClap(int clapIndex, bool ignore)
        {
            if (clapIndex >= 0 && clapIndex < _ignoreClaps.Count)
                _ignoreClaps[clapIndex] = ignore;
        }

        // Checks whether two rhythms follow the same pattern.
        // By the word "pattern" we not referring to claps nor do we refer to a rhythm structure.
        public bool IsIdentical(Rhythm anotherRhythm)
        {
            List<bool> anotherIgnoreClaps = anotherRhythm._ignoreClaps;

            for (int i = 0; i < _ignoreClaps.Count; i++)
                if (anotherIgnoreClaps[i] != _ignoreClaps[i])
                    return false;

            if (_rhythmType == anotherRhythm.RhythmType)
                return true;

            return false;
        }

        // Combine two different rhythms.
        public void ConcatenateRhythm(Rhythm anotherRhythm, int timeInBetween)
        {
            Rhythm rhythm = ConcatenateRhythm(this, anotherRhythm, timeInBetween);

            _rhythmStructure = rhythm._rhythmStructure;
            _ignoreClaps = rhythm._ignoreClaps;
            _isComputerGenerated = rhythm._isComputerGenerated;
            _rhythmClass = rhythm._rhythmClass;
            _rhythmType = rhythm._rhythmType;

        }

        // Combine two different rhythms.
        public static Rhythm ConcatenateRhythm(Rhythm rhythm1, Rhythm rhythm2, int timeInBetween)
        {
            Dictionary<int, int> structure = new Dictionary<int, int>();
            List<bool> ignoreClaps = new List<bool>();
            int timeToAdd = rhythm1._rhythmStructure.Last().Key;

            if (!rhythm1._isComputerGenerated && !rhythm2._isComputerGenerated)
            {
                if (timeInBetween % 1000 == 0)
                    timeToAdd += Math.Abs(timeInBetween);
                else
                    throw new Exception("The time between two rhythms must divisible by 1000.");
            }
            else
            {
                timeToAdd += Math.Abs(timeInBetween);
            }


            foreach (KeyValuePair<int, int> entry in rhythm1._rhythmStructure)
                structure.Add(entry.Key, entry.Value);

            foreach (KeyValuePair<int, int> entry in rhythm2._rhythmStructure)
                structure.Add(entry.Key + timeToAdd, entry.Value);


            foreach (bool ignoreClap in rhythm1._ignoreClaps)
                ignoreClaps.Add(ignoreClap);
            foreach (bool ignoreClap in rhythm2._ignoreClaps)
                ignoreClaps.Add(ignoreClap);



            return new Rhythm((rhythm1._rhythmClass == rhythm2._rhythmClass) ? rhythm1._rhythmClass : RhythmClass.GENERAL_RHYTHM,
                              structure, ignoreClaps, rhythm1._isComputerGenerated || rhythm2._isComputerGenerated);
        }

        // Display Rhythm
        public void DisplayRhythm()
        {
            Console.WriteLine("\n" + ToString());
        }

        public override string ToString()
        {
            string presentation = "";

            presentation += (_isComputerGenerated) ? "Computer Generated % " : "Isn't Generated % ";

            if (_rhythmType == RhythmType.SIMILAR_CLAPS)
                presentation += "Similar Claps % ";
            else if (_rhythmType == RhythmType.TWO_ALTERNATING_DISTINCT_CLAPS)
                presentation += "Two Alternating Claps % ";
            else if (_rhythmType == RhythmType.THREE_ALTERNATING_DISTINCT_CLAPS)
                presentation += "Three Alternating Claps % ";
            else
                presentation += "General Claps % ";

            switch (_rhythmClass)
            {
                case RhythmClass.RHYTHM_ONE:
                    presentation += "RHYTHM_ONE % ";
                    break;
                case RhythmClass.RHYTHM_TWO:
                    presentation += "RHYTHM_TWO % ";
                    break;
                case RhythmClass.RHYTHM_THREE:
                    presentation += "RHYTHM_THREE % ";
                    break;
                case RhythmClass.RHYTHM_FOUR:
                    presentation += "RHYTHM_FOUR % ";
                    break;
                case RhythmClass.RHYTHM_FIVE:
                    presentation += "RHYTHM_FIVE % ";
                    break;
                case RhythmClass.RHYTHM_SIX:
                    presentation += "RHYTHM_SIX % ";
                    break;
                case RhythmClass.RHYTHM_SEVEN:
                    presentation += "RHYTHM_SEVEN % ";
                    break;
                case RhythmClass.RHYTHM_EIGHT:
                    presentation += "RHYTHM_EIGHT % ";
                    break;
                case RhythmClass.RHYTHM_NINE:
                    presentation += "RHYTHM_NINE % ";
                    break;
                case RhythmClass.RHYTHM_TEN:
                    presentation += "RHYTHM_TEN % ";
                    break;
                case RhythmClass.RHYTHM_ELEVEN:
                    presentation += "RHYTHM_ELEVEN % ";
                    break;
                case RhythmClass.RHYTHM_TWELVE:
                    presentation += "RHYTHM_TWELVE % ";
                    break;
                default:
                    presentation += "COMPLEX_RHYTHM % ";
                    break;
            }

            int indexOf = -1;
            presentation += "\n\t\tTime\t\t\tClaps\t\t\tIgnore\n";
            foreach (KeyValuePair<int, int> entry in _rhythmStructure)
            {

                presentation += ("\t\t" + entry.Key + "\t\t\t" + entry.Value + "\t\t\t" + (_ignoreClaps[++indexOf] + "\n"));
            }

            return presentation;
        }
    }
}
