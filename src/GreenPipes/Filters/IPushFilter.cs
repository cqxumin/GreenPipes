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
namespace GreenPipes.Filters
{
    /// <summary>
    /// Supports adding filters to a pipe at the reserved location
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPushFilter<T>
        where T : class, PipeContext
    {
        /// <summary>
        /// Add the filter to the pipe
        /// </summary>
        /// <param name="filter"></param>
        void Add(IFilter<T> filter);
    }
}