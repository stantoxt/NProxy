﻿//
// NProxy is a library for the .NET framework to create lightweight dynamic proxies.
// Copyright © Martin Tamme
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;

namespace NProxy.Core
{
    /// <summary>
    /// Provides proxy factory extensions.
    /// </summary>
    public static class ProxyFactoryExtensions
    {
        /// <summary>
        /// Creates a proxy.
        /// </summary>
        /// <typeparam name="T">The declaring type.</typeparam>
        /// <param name="proxyFactory">The proxy factory.</param>
        /// <param name="interfaceTypes">The additional interface types.</param>
        /// <returns>The proxy.</returns>
        public static IProxy<T> CreateProxy<T>(this IProxyFactory proxyFactory, IEnumerable<Type> interfaceTypes) where T : class
        {
            var proxy = proxyFactory.CreateProxy(typeof (T), interfaceTypes);

            return new Proxy<T>(proxy);
        }

        /// <summary>
        /// Creates a proxy object.
        /// </summary>
        /// <param name="proxyFactory">The proxy factory.</param>
        /// <param name="declaringType">The declaring type.</param>
        /// <param name="interfaceTypes">The additional interface types.</param>
        /// <param name="invocationHandler">The invocation handler.</param>
        /// <param name="arguments">The constructor arguments.</param>
        /// <returns>The proxy object.</returns>
        public static object CreateProxy(this IProxyFactory proxyFactory,
                                         Type declaringType,
                                         IEnumerable<Type> interfaceTypes,
                                         IInvocationHandler invocationHandler,
                                         params object[] arguments)
        {
            if (proxyFactory == null)
                throw new ArgumentNullException("proxyFactory");

            var proxy = proxyFactory.CreateProxy(declaringType, interfaceTypes);

            return proxy.CreateInstance(invocationHandler, arguments);
        }

        /// <summary>
        /// Creates a proxy object.
        /// </summary>
        /// <typeparam name="T">The declaring type.</typeparam>
        /// <param name="proxyFactory">The proxy factory.</param>
        /// <param name="interfaceTypes">The additional interface types.</param>
        /// <param name="invocationHandler">The invocation handler.</param>
        /// <param name="arguments">The constructor arguments.</param>
        /// <returns>The proxy object.</returns>
        public static T CreateProxy<T>(this IProxyFactory proxyFactory,
                                       IEnumerable<Type> interfaceTypes,
                                       IInvocationHandler invocationHandler,
                                       params object[] arguments) where T : class
        {
            if (proxyFactory == null)
                throw new ArgumentNullException("proxyFactory");

            var proxy = proxyFactory.CreateProxy<T>(interfaceTypes);

            return proxy.CreateInstance(invocationHandler, arguments);
        }
    }
}