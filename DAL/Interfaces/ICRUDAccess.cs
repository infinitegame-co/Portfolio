using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICRUDAccess<T>
    {
        /// <summary>
        /// Gets Matching entry (will ignore index)
        /// </summary>
        /// <param name="obj">entry to search for</param>
        /// <returns>returns found entry with index</returns>
        T Get(T obj);
        void Create(T obj);
        /// <summary>
        /// Updates entry with new instance
        /// </summary>
        /// <param name="Original">Original Entry</param>
        /// <param name="Replacement">Entry to replace original</param>
        void Update(T Original, T Replacement);
        /// <summary>
        /// deletes entry at index
        /// </summary>
        /// <param name="index">index to delete at</param>
        void Delete(int index);
        /// <summary>
        /// Gets the entry at index
        /// </summary>
        /// <param name="index">index to get from</param>
        /// <returns>entry at index</returns>
        T Read(int index);
        /// <summary>
        /// Gets te latest entry in the collection
        /// </summary>
        /// <returns>Latest entry in collection</returns>
        T GetLatestEntry();
    }
}
