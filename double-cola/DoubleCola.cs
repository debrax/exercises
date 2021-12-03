using System.Collections.Generic;
using System.Linq;

namespace DoubleCola
{
    public class DoubleCola
    {
        // Constant for domain
        public const string Nobody = null;

        // Queue data structure for a queue problem
        private Queue<DrinkerDoubles> drinkerQueue;

        /// <summary>
        /// Initializes the program with the ordered names of the initial queue.
        /// </summary>
        public DoubleCola(string[] drinkerNames)
        {
            // Invalid argument considered as empty
            drinkerNames = drinkerNames ?? new string[0];

            // Optimization: drinker clones grouped
            // Space: O(n²) => O(n)
            var initialDrinkers = drinkerNames.Select(name => new DrinkerDoubles(name));
            drinkerQueue = new Queue<DrinkerDoubles>(initialDrinkers);
        }

		/// <summary>
		/// Returns the name of the n-th cola drinker or Nobody if no drinker or no cola is drunk.
		/// <summary>
        public string GetNthColaDrinker(long remainingColas)
        {
            if (HasNoDrinker() || IsNoColaDrunk(remainingColas))
                return Nobody;

            while (IsNotLastCola(remainingColas))
            {
                var drinkerDoubles = drinkerQueue.Dequeue();

                // Optimization: prevent unnecessary doubles
                if (IsNthDrinkerAmongDoubles(remainingColas, drinkerDoubles.Count))
                    return drinkerDoubles.Name;

                // Optimization: all doubles drink cola in once
                // Time: O(n) => O(1)
                remainingColas -= drinkerDoubles.Count;
                drinkerDoubles.Double();

                drinkerQueue.Enqueue(drinkerDoubles);
            }

            // Last cola reached
            return drinkerQueue.Dequeue().Name;
        }

        private bool HasNoDrinker() => drinkerQueue.Count == 0;

        // Negative number of drunk considered as 0
        private static bool IsNoColaDrunk(long n) => n <= 0;

        private static bool IsNotLastCola(long n) => n > 1;

        private static bool IsNthDrinkerAmongDoubles(long n, long doublesCount) => n < doublesCount;

        private class DrinkerDoubles
        {
            public string Name { get; }
            public long Count { get; private set; }

            /// <summary>
            /// Initializes the doubles with the given name and a count of 1.
            /// </summary>
            public DrinkerDoubles(string name)
            {
                Name = name;
                Count = 1;
            }

            public void Double() => Count *= 2;
        }
    }
}
