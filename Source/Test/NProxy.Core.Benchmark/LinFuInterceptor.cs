﻿//
// Copyright © Martin Tamme
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using LinFu.AOP.Interfaces;

namespace NProxy.Core.Benchmark
{
    internal sealed class LinFuInterceptor : IInterceptor
    {
        private readonly object _target;

        public LinFuInterceptor(object target)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            _target = target;
        }

        #region IInterceptor Members

        public object Intercept(IInvocationInfo info)
        {
            return info.TargetMethod.Invoke(_target, info.Arguments);
        }

        #endregion
    }
}