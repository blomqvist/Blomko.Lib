using System;

namespace Blomko.Lib.WeightedRandom
{
    /// <summary>
    /// Wrapper for a generic <see cref="Tuple{T, Double}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WeightedParameter<T> : Tuple<T, double>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value to return</param>
        /// <param name="weight">The weight of returning this when randomizing</param>
        public WeightedParameter(T value, double weight)
            : base(value, weight)
        {
        }

        /// <summary>
        /// The object to be "randomly" distributed
        /// </summary>
        public T Value => Item1;

        /// <summary>
        /// The weight (chance) of being chosen when randomizing
        /// 
        /// Higher weight = greater chance
        /// </summary>
        public double Weight => Item2;
    }
}
