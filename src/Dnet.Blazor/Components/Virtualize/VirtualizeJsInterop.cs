// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Dnet.Blazor.Components.Virtualize
{
    [method: DynamicDependency(nameof(OnSpacerBeforeVisible))]
    [method: DynamicDependency(nameof(OnSpacerAfterVisible))]
    internal class VirtualizeJsInterop(IVirtualizeJsCallbacks owner, IJSRuntime jsRuntime) : IAsyncDisposable
    {
        private const string JsFunctionsPrefix = "Blazor._internal.Virtualize";
        private DotNetObjectReference<VirtualizeJsInterop>? _selfReference;

        public async ValueTask InitializeAsync(ElementReference spacerBefore, ElementReference spacerAfter)
        {
            _selfReference = DotNetObjectReference.Create(this);
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.init", _selfReference, spacerBefore, spacerAfter);
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
