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

namespace NProxy.Core.Aop
{
    /// <summary>
    /// Defines an advisor.
    /// </summary>
    public interface IAdvisor
    {
        /// <summary>
        /// Return whether this advice is associated with a particular instance
        /// (for example, creating a mixin) or shared with all instances of the
        /// advised class obtained from the same Spring bean factory.
        /// </summary>
        bool IsPerInstance { get; }

        /// <summary>
        ///  Return the advice part of this aspect.
        /// </summary>
        IAdvice Advice { get; }
    }
}