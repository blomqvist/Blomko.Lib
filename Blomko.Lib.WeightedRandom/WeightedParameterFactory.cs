namespace Blomko.Lib.WeightedRandom
{
    /// <summary>
    /// Factory for creating <see cref="WeightedParameter{T}"/>, so that T can be inferred
    /// </summary>
    public class WeightedParameterFactory
    {
        /// <summary>
        /// Creates a <see cref="WeightedParameter{T}"/>
        /// </summary>
        public static WeightedParameter<T> Create<T>(T value, double weight)
        {
            return new WeightedParameter<T>(value, weight);
        }
    }
}