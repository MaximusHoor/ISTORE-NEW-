using System;
using Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessTest.Repository.Factory
{
    internal class ContextSingleton
    {
        private static readonly Lazy<StoreContext> _context =
            new Lazy<StoreContext>(() => new StoreContext(new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options));

        private ContextSingleton()
        {
        }

        public static StoreContext GetDatabaseContext()
        {
            return _context.Value;
        }
    }
}