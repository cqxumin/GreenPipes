﻿// Copyright 2012-2018 Chris Patterson
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
namespace GreenPipes.Caching
{
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface ICache<TValue> :
        IConnectCacheValueObserver<TValue>
        where TValue : class
    {
        /// <summary>
        ///     Create an index on the cache for the specified key type
        /// </summary>
        /// <param name="name">A unique index name</param>
        /// <param name="keyProvider">The key factory for the value</param>
        /// <param name="missingValueFactory"></param>
        /// <typeparam name="TKey">The key type for the index</typeparam>
        /// <returns>The index, which can be used directly to access the cache</returns>
        IIndex<TKey, TValue> AddIndex<TKey>(string name, KeyProvider<TKey, TValue> keyProvider, MissingValueFactory<TKey, TValue> missingValueFactory = null);

        /// <summary>
        ///     Get an existing cache index by name
        /// </summary>
        /// <param name="name"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        IIndex<TKey, TValue> GetIndex<TKey>(string name);

        /// <summary>
        /// Adds a value, updating indices, before returning
        /// </summary>
        /// <param name="value">The value to add</param>
        void Add(TValue value);

        /// <summary>
        ///     Returns all the values in the cache
        /// </summary>
        /// <returns></returns>
        IEnumerable<Task<TValue>> GetAll();

        /// <summary>
        ///     Forcibly clear the cache immediately (disposal of cached items may take some time, occurs asynchronously)
        /// </summary>
        void Clear();
    }
}