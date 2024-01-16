// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Threading;

namespace Dnet.Blazor.Components.Grid.Virtualize
{
    /// <summary>
    /// Represents a request to an <see cref="ItemsProviderDelegate{TItem}"/>.
    /// </summary>
    /// <remarks>
    /// Constructs a new <see cref="ItemsProviderRequest"/> instance.
    /// </remarks>
    /// <param name="startIndex">The start index of the data segment requested.</param>
    /// <param name="count">The requested number of items to be provided.</param>
    /// <param name="cancellationToken">
    /// The <see cref="System.Threading.CancellationToken"/> used to relay cancellation of the request.
    /// </param>
    public readonly struct ItemsProviderRequest(int startIndex, int count, CancellationToken cancellationToken)
    {
        /// <summary>
        /// The start index of the data segment requested.
        /// </summary>
        public int StartIndex { get; } = startIndex;

        /// <summary>
        /// The requested number of items to be provided. The actual number of provided items does not need to match
        /// this value.
        /// </summary>
        public int Count { get; } = count;

        /// <summary>
        /// The <see cref="System.Threading.CancellationToken"/> used to relay cancellation of the request.
        /// </summary>
        public CancellationToken CancellationToken { get; } = cancellationToken;
    }
}
