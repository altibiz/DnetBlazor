// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Dnet.Blazor.Components.Grid.Virtualize
{
    internal class VirtualizeJsInterop(IVirtualizeJsCallbacks owner, IJSRuntime jsRuntime) : IAsyncDisposable
    {
        private const string JsFunctionsPrefix = "blginterop";
        private DotNetObjectReference<VirtualizeJsInterop>? _selfReference;

        public async ValueTask InitializeAsync(ElementReference spacerBefore, ElementReference spacerAfter, int rootMargin = 50)
        {
            _selfReference = DotNetObjectReference.Create(this);
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.init", _selfReference, spacerBefore, spacerAfter, rootMargin);
        }

        [JSInvokable]
        public void OnSpacerBeforeVisible(float spacerSize, float spacerSeparation, float containerSize)
        {
            owner.OnBeforeSpacerVisible(spacerSize, spacerSeparation, containerSize);
        }

        [JSInvokable]
        public void OnSpacerAfterVisible(float spacerSize, float spacerSeparation, float containerSize)
        {
            owner.OnAfterSpacerVisible(spacerSize, spacerSeparation, containerSize);
        }

        public async ValueTask DisposeAsync()
        {
            if (_selfReference != null)
            {
                try
                {
                    await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.dispose", _selfReference);
                }
                catch (JSDisconnectedException)
                {
                    // If the browser is gone, we don't need it to clean up any browser-side state
                }
            }
        }
    }
}
