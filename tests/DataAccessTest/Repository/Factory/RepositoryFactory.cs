using System;

namespace DataAccessTest.Repository.Factory
{
    internal class RepositoryFactory
    {
        internal static T Instance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T), ContextSingleton.GetDatabaseContext());
        }
    }
}