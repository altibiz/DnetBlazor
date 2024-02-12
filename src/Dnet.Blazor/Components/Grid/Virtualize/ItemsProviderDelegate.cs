// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace Dnet.Blazor.Components.Grid.Virtualize
{
    /// <summary>
    /// A function that provides items to a virtualized source.
    /// </summary>
    /// <typeparam name="TItem">The type of the context for each item in the list.</typeparam>
    /// <param name="request">The <see cref="ItemsProviderRequest"/> defining the request details.</param>
    /// <returns>A <see cref="ValueTask"/> whose result is a <see cref="ItemsProviderResult{TItem}"/> upon successful completion.</returns>
    public delegate ValueTask<ItemsProviderResult<TItem>> ItemsProviderDelegate<TItem>(ItemsProviderRequest request);
}
