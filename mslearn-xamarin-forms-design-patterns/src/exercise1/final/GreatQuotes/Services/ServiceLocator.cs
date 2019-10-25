using System;
using System.Collections.Generic;

namespace GreatQuotes.Services
{
    /// <summary>
    /// Simple ServiceLocator implementation.
    /// </summary>
    public sealed class ServiceLocator
    {
        private static readonly Lazy<ServiceLocator> instance = new Lazy<ServiceLocator>(() => new ServiceLocator());
        private readonly Dictionary<Type, Lazy<object>> registeredServices = new Dictionary<Type, Lazy<object>>();

        /// <summary>
        /// Singleton instance for default service locator
        /// </summary>
        public static ServiceLocator Instance => instance.Value;

        /// <summary>
        /// Add a new contract + service implementation
        /// </summary>
        /// <typeparam name="TContract">Contract type</typeparam>
        /// <typeparam name="TService">Service type</typeparam>
        public void Add<TContract, TService>() where TService : new()
        {
            registeredServices[typeof(TContract)] =
                new Lazy<object>(() => Activator.CreateInstance(typeof(TService)));
        }

        /// <summary>
        /// This resolves a service type and returns the implementation. Note that this
        /// assumes the key used to register the object is of the appropriate type or
        /// this method will throw an InvalidCastException!
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Implementation</returns>
        public T Resolve<T>()
        {
            if (registeredServices.TryGetValue(typeof(T), out Lazy<object> service))
            {
                return (T)service.Value;
            }

            throw new Exception("No service found for " + typeof(T).Name);
        }
    }
}