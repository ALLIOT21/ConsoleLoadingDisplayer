using System.Collections.Generic;
using System.Linq;

namespace BestLoadingDisplayerEver
{
    internal class CircularSequenceGenerator<T>
    {
        private readonly IEnumerable<T> _sequence;

        private int _currentIndex = 0;
        private int _sequenceLength;

        public CircularSequenceGenerator(IEnumerable<T> sequence)
        {
            _sequence = sequence;
            _sequenceLength = _sequence.Count();
        }

        public T Next()
        {
            int currentIndex = _currentIndex;

            Proceed();

            return _sequence.ElementAt(currentIndex);
        }

        private void Proceed()
        {
            _currentIndex = (_currentIndex + 1) % _sequenceLength;
        }
    }
}
