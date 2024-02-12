// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Dnet.Blazor.Components.Virtualize
{
    /// <summary>
    /// Represents the result of a <see cref="ItemsProviderDelegate{TItem}"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the context for each item in the list.</typeparam>
    /// <remarks>
    /// Instantiates a new <see cref="ItemsProviderResult{TItem}"/> instance.
    /// </remarks>
    /// <param name="items">The items to provide.</param>
    /// <param name="totalItemCount">The total item count in the source generating the items provided.</param>
    public readonly struct ItemsProviderResult<TItem>(IEnumerable<TItem> items, int totalItemCount)
    {
        /// <summary>
        /// The items to provide.
        /// </summary>
        public IEnumerable<TItem> Items { get; } = items;

        /// <summary>
        /// The total item count in the source generating the items provided.
        /// </summary>
        public int TotalItemCount { get; } = totalItemCount;
    }
}
