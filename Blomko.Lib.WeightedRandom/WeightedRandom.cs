using System;
using System.Collections.Generic;
using System.Linq;

namespace Blomko.Lib.WeightedRandom
{
    /// <summary>
    /// Generates random values of type T using the supplied distribution.
    /// 
    /// Is most easily used in conjuction with the <see cref="WeightedParameterFactory"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WeightedRandom<T>
    {
        /// <summary>
        /// Collection of values and weights
        /// </summary>
        public ICollection<WeightedParameter<T>> WeightedParameters { get; set; }
        private readonly Random random;

        /// <summary>
        /// The sum of all weights
        /// </summary>
        public double WeightSum => WeightedParameters.Sum(p => p.Weight);

        private WeightedRandom()
        {
            random = new Random();
        }

        /// <summary>
        /// Creates an instance of <see cref="WeightedRandom{T}"/>
        /// </summary>
        /// <param name="weightedRandomParameters"></param>
        public WeightedRandom(ICollection<WeightedParameter<T>> weightedRandomParameters)
            : this()
        {
            WeightedParameters = weightedRandomParameters;
        }

        /// <summary>
        /// Creates an instance of <see cref="WeightedRandom{T}"/>
        /// </summary>
        /// <param name="weightedRandomParameters"></param>
        public WeightedRandom(params WeightedParameter<T>[] weightedRandomParameters)
            : this()
        {
            WeightedParameters = weightedRandomParameters;
        }

        /// <summary>
        /// Generates the next number, taking the distribution weight into account
        /// </summary>
        /// <returns><typeparamref name="T"/></returns>
        public T Next()
        {
            var numericValue = random.NextDouble() * WeightSum;
            foreach (var parameter in WeightedParameters)
            {
                numericValue -= parameter.Weight;
                if (numericValue <= 0)
                {
                    return parameter.Value;
                }
            }

            return default;
        }
    }
}
