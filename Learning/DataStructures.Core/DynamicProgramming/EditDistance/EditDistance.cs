using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Core.DynamicProgramming.EditDistance
{
    public class EditDistance
    {
        private string _firstString;
        private string _secondString;

        private int[,] _store;

        public EditDistance() { }

        public int Find(string firstString, string secondString)
        {
            _firstString = firstString;
            _secondString = secondString;

            _store = new int[_firstString.Length, _secondString.Length];
            for (var indexI = 0; indexI < _firstString.Length; indexI++)
            {
                for (var indexJ = 0; indexJ < _secondString.Length; indexJ++)
                {
                    _store[indexI, indexJ] = -1;
                }
            }

            //return EditDistanceRecursive(_firstString.Length, _secondString.Length);
            //return EditDistanceRecursiveMemoization(_firstString.Length, _secondString.Length);
            return EditDistanceDynamicProgramming();
        }

        #region Private methods

        private int EditDistanceRecursive(int sOneLength, int sTwoLength)
        {
            if (sOneLength == 0)
                return sTwoLength;
            if (sTwoLength == 0)
                return sOneLength;

            if (_firstString[sOneLength - 1] == _secondString[sTwoLength - 1])
                return EditDistanceRecursive(sOneLength - 1, sTwoLength - 1);
            else
            {
                var insertTries = 1 + EditDistanceRecursive(sOneLength, sTwoLength - 1);
                var removeTries = 1 + EditDistanceRecursive(sOneLength - 1, sTwoLength);
                var deleteTries = 1 + EditDistanceRecursive(sOneLength - 1, sTwoLength - 1);

                return Math.Min(insertTries, Math.Min(removeTries, deleteTries));
            }
        }

        private int EditDistanceRecursiveMemoization(int sOneLength, int sTwoLength)
        {
            if (sOneLength == 0)
                return sTwoLength;
            if (sTwoLength == 0)
                return sOneLength;

            if (_store[sOneLength - 1, sTwoLength - 1] != -1)
                return _store[sOneLength - 1, sTwoLength - 1];

            if (_firstString[sOneLength - 1] == _secondString[sTwoLength - 1])
            {
                var result = EditDistanceRecursive(sOneLength - 1, sTwoLength - 1);
                _store[sOneLength - 1, sTwoLength - 1] = result;

                return _store[sOneLength - 1, sTwoLength - 1];
            }
            else
            {
                var insertTries = 1 + EditDistanceRecursive(sOneLength, sTwoLength - 1);
                var removeTries = 1 + EditDistanceRecursive(sOneLength - 1, sTwoLength);
                var deleteTries = 1 + EditDistanceRecursive(sOneLength - 1, sTwoLength - 1);

                var result = Math.Min(insertTries, Math.Min(removeTries, deleteTries));
                _store[sOneLength - 1, sTwoLength - 1] = result;

                return _store[sOneLength - 1, sTwoLength - 1];
            }
        }

        private int EditDistanceDynamicProgramming()
        {
            _store = new int[_firstString.Length + 1, _secondString.Length + 1];
            for (var indexI = 0; indexI < _firstString.Length; indexI++)
            {
                for (var indexJ = 0; indexJ < _secondString.Length; indexJ++)
                {
                    if (indexI == 0)
                        _store[indexI, indexJ] = indexJ;
                    if (indexJ == 0)
                        _store[indexI, indexJ] = indexI;
                }
            }

            for (var indexI = 1; indexI <= _firstString.Length; indexI++)
            {
                for (var indexJ = 1; indexJ <= _secondString.Length; indexJ++)
                {
                    if (_firstString[indexI - 1] == _secondString[indexJ - 1])
                    {
                        _store[indexI, indexJ] = _store[indexI - 1, indexJ - 1];
                        continue;
                    }

                    var insertTries = 1 + _store[indexI, indexJ - 1];
                    var removeTries = 1 + _store[indexI - 1, indexJ];
                    var deleteTries = 1 + _store[indexI - 1, indexJ - 1];

                    var result = Math.Min(insertTries, Math.Min(removeTries, deleteTries));
                    _store[indexI, indexJ] = result;
                }
            }

            return _store[_firstString.Length, _secondString.Length];
        }

        #endregion
    }
}
