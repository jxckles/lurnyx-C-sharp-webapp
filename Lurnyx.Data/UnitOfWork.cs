﻿using Lurnyx.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data
{

    /// <summary>
    /// Unit of Work Implementation
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Gets the database context
        /// </summary>
        public DbContext Database { get; private set; }

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="serviceContext">The service context.</param>
        public UnitOfWork(LurnyxDBContext serviceContext)
        {
            Database = serviceContext;
        }

        /// <summary>
        /// Saves the changes to database
        /// </summary>
        public void SaveChanges()
        {
            Database.SaveChanges();
        }


        /// <summary>
        /// Saves the changes to database asynchronously
        /// </summary>
        /// <returns>The number of state entries written to the underlying database.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await Database.SaveChangesAsync();
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
